using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(
            IReviewRepository reviewRepository,
            ILogger<ReviewService> logger
            )
        {
            _reviewRepository = reviewRepository;
            _logger = logger;
        }

        public Task<string> DeleteReview(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetRecentReviews(int quantity)
        {
            try
            {
                return this._reviewRepository.GetRecentReviews(quantity);
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
                return this._reviewRepository.GetReviews(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> SetReview(Review review)
        {
            try
            {
                return this._reviewRepository.SetReview(review);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
