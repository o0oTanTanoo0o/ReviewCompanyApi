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
        ResponseList<IEnumerable<Review>> GetReviews(FilterReview filter);
        Task<Review> GetReviewById(string id);
        Task<string> SetReview(Review review);
        Task<string> DeleteReview(string id);
    }
}
