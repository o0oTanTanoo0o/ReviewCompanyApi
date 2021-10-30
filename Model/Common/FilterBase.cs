using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Models.Common
{
    public class FilterBase
    {
        public FilterBase()
        {
        }
        //[Required(ErrorMessage = "projectCd không được trống")]
        [FromQuery(Name = "filter")]
        [DefaultValue("")]
        public string filter { get; set; }
        [FromQuery(Name = "offSet")]
        [DefaultValue(0)]
        public int? offSet { get; set; }
        [FromQuery(Name = "pageSize")]
        [DefaultValue(0)]
        public int? pageSize { get; set; }
        public FilterBase(string filter = "", int? offSet = 0, int? pageSize = 10)
        {
            this.filter = filter;
            this.offSet = offSet;
            this.pageSize = pageSize;
        }
    }


    public class FilterBasePackage: FilterBase
    {
        public bool? IsIncome { get; set; } = null;
    }

    public class FilterTransaction : FilterBase
    {
        public int? year{ set; get; } = null;
        public int? month{ set; get; } = null;
        public string? walletId { set; get; } = null;
        public string? accountId { set; get; } = null;
    }

    public class FilterDevice : FilterBase
    {
        public string? accountId { set; get; } = null;

    }
    public class FilterReview : FilterBase
    {
        public string companyId { set; get; } = null;
    }
}
