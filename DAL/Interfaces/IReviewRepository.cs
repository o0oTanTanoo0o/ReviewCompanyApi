using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReviewRepository
    {
        ResponseList<IEnumerable<Review>> GetReviews(FilterReview filter);
        Task<Review> GetReviewById(string id);
        Task<string> SetReview(Review review);
        Task<string> DeleteReview(string id);
    }
}
