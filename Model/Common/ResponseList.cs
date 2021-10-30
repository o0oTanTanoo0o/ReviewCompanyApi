using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public class ResponseList<T> : BaseResponse<T>
    {
        public ResponseList()
        {
        }
        public ResponseList(ApiResult status) : base(status) { }

        public ResponseList(ApiResult status, string error) : base(status, error) { }

        public ResponseList(ApiResult status, T data) : base(status, data) { }

        public ResponseList(ApiResult status, T data, string error) : base(status, data, error) { }

        public ResponseList(ApiResult status, T data, long recordsTotal, long recordsFiltered) : base(status, data)
        {
            this.RecordsTotal = recordsTotal;
            this.RecordsFiltered = recordsFiltered;
        }

        public ResponseList(T data, long recordsTotal, long recordsFiltered) : base(data)
        {
            this.RecordsTotal = recordsTotal;
            this.RecordsFiltered = recordsFiltered;
        }

        public ResponseList(T data, long recordsTotal) : base(data)
        {
            this.RecordsTotal = recordsTotal;
        }

        public long RecordsTotal { get; set; }
        public long RecordsFiltered { get; set; }
    }

}