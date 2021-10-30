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

        public ResponseList<IEnumerable<Review>> GetReviews(FilterReview filter)
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
                    var reviewAll = connection.Query<Review>(storeProcedureName, param, commandType: CommandType.StoredProcedure);
                    var reviews = reviewAll.Where(review => review.ParentId == null).ToList();
                    foreach(Review review in reviews)
                    {
                        review.Replies = reviewAll.Where(t => t.ParentId == review.Id).ToList();
                    }
                    var result = new ResponseList<IEnumerable<Review>>(reviews, param.Get<int>("@total"), param.Get<int>("@totalFiltered"));
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> SetReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
