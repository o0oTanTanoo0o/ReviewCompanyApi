using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReviewService
    {
        ResponseList<ReviewDetail> GetReviews(FilterReview filter);
        IEnumerable<Review> GetRecentReviews(int quantity);
        Task<Review> GetReviewById(string id);
        Task<string> SetReview(Review review);
        Task<string> DeleteReview(string id);
    }
}
