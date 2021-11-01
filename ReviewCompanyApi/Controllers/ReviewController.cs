using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewCompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        IReviewService _reviewService;
        public ReviewController(
             IReviewService reviewService
            )
        {
            this._reviewService = reviewService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Review>>> GetReview([FromQuery] FilterReview search)
        {
            try
            {
                ResponseList<IEnumerable<Review>> result = _reviewService.GetReviews(search);
                return new BaseResponse<ResponseList<IEnumerable<Review>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Review>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Review>> GetReviewById(string id)
        {
            try
            {
                Review result = await _reviewService.GetReviewById(id);
                return new BaseResponse<Review>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Review>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<string>> SetReview([FromBody] Review review)
        {
            try
            {
                string result = await _reviewService.SetReview(review);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<string>> DeleteReview(string id)
        {
            try
            {
                string result = await _reviewService.DeleteReview(id);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, "", ex.Message, ex.Message);
            }
        }
    }
}
