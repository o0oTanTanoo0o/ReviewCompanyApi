using DAL.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ReviewRepository> _logger;
        public ReviewRepository(
             IConfiguration configuration,
             ILogger<ReviewRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("ReviewCompanyConnection");
            _logger = logger;
        }
        public async Task<string> DeleteReview(string id)
        {
            try
            {
                const string storeProcedureName = "Review_Delete";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    await connection.QueryAsync<Company>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Review> GetReviewById(string id)
        {
            throw new NotImplementedException();
        }

        public ResponseList<ReviewDetail> GetReviews(FilterReview filter)
        {
            try
            {
                const string storeProcedureName = "Review_Get_List";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@companyId", filter.companyId);
                    param.Add("@filter", filter.filter);
                    param.Add("@offset", filter.offSet);
                    param.Add("@pageSize", filter.pageSize);
                    param.Add("@total", 0, DbType.Int32, ParameterDirection.InputOutput);
                    param.Add("@totalFiltered", 0, DbType.Int32, ParameterDirection.InputOutput);
                    var response = connection.QueryMultiple(storeProcedureName, param, commandType: CommandType.StoredProcedure);


                    var reviewAll = response.Read<Review>().ToList();
                    var reviews = reviewAll.Where(review => review.ParentId == null).ToList();
                    foreach(Review review in reviews)
                    {
                        review.Replies = reviewAll.Where(t => t.ParentId == review.Id).ToList();
                    }

                    var ratingPercent = response.Read<decimal>().ToList();

                    var result = new ReviewDetail() { Review = reviews, RatingsAverage = ratingPercent };
                    return new ResponseList<ReviewDetail>(result, param.Get<int>("@total"), param.Get<int>("@totalFiltered")); ;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<string> SetReview(Review review)
        {
            try
            {
                const string storeProcedureName = "Review_Set";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", review.Id);
                    param.Add("@ParentId", review.ParentId);
                    param.Add("@Created", review.Created);
                    param.Add("@UserName", review.UserName);
                    param.Add("@Comment", review.Comment);
                    param.Add("@IsFavourite", review.IsFavourite);
                    param.Add("@Time", review.Time);
                    param.Add("@Rating", review.Rating);
                    param.Add("@CompanyId", review.CompanyId);
                    param.Add("@Favourite", review.Favourite);
                    param.Add("@OutputRequestId", "", DbType.String, ParameterDirection.InputOutput);
                    var result = await connection.ExecuteAsync(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@OutputRequestId");
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
