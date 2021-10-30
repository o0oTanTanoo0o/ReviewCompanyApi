using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public enum ApiResult
    {
        Success = 200,
        InsertSuccess = 201,
        NotFound = 404,
        Fail = 500
    }
}
