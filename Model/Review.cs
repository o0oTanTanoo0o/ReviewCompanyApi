using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Review
    {
        public string? Id { set; get; }
        public string? ParentId { set; get; }
        public decimal? Created { set; get; }
        public string? UserName { set; get; }
        public string? Comment { set; get; }
        public string? IsFavourite { set; get; }
        public string? Time { set; get; }
        public string? Star { set; get; }
        public int? CompanyId { set; get; }
        public string? CompanyName { set; get; }
        public int? Favourite { set; get; }
        public int? Rating { set; get; }
        public List<Review>? Replies { set; get; }
    }

    public class ReviewDetail
    {
        public List<Review> Review { set; get; }
        public List<decimal> RatingsAverage { set; get; }
    }
}
