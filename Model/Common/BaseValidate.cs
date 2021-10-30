using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public class BaseValidate
    {
        public BaseValidate()
        {
        }

        public BaseValidate(int statusCode, string message)
        {
            StatusCode = statusCode;
            Messages = message;
        }
        public int StatusCode { get; set; }
        public string Messages { get; set; }
    }
}
