using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public class BaseResponse<T>
    {
        public int StatusCode { set; get; }
        public string Message { set; get; }
        public string Status { set; get; }
        public T Data { set; get; }
        public List<string> Error { set; get; }
        public void AddError(string error)
        {

            if (Error == null)
            {
                Error = new List<string>();
            }
            Error.Add(error);
        }

        public void AddError(ApiResult status, string error)
        {
            SetStatus(status);
            AddError(error);
        }

        public void AddErrors(List<string> errors)
        {

            if (Error == null)
            {
                Error = new List<string>();
            }
            Error.AddRange(errors);
        }

        public void AddErrors(ApiResult status, List<string> errors)
        {
            SetStatus(status);
            AddErrors(errors);
        }

        public BaseResponse(T data)
        {
            SetStatus(ApiResult.Success);
            Data = data;
        }

        public BaseResponse()
        {
            SetStatus(ApiResult.Success);
        }
        public void SetStatus(ApiResult status)
        {
            switch (status)
            {
                case (ApiResult.Success):
                    StatusCode = (int)ApiResult.Success;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Fail):
                    StatusCode = (int)ApiResult.Fail;
                    Status = Constants.Statusfail;
                    break;
                default:
                    break;
            }
        }

        public void SetMessage(string message)
        {
            this.Message = message;
        }

        public void SetStatus(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public BaseResponse(ApiResult status, T data = default, string error = null, string message = "")
        {
            SetStatus(status);

            if (data != null)
            {
                Data = data;
            }

            if (!string.IsNullOrEmpty(error))
            {
                AddError(error);
            }

            if (!string.IsNullOrEmpty(message))
            {
                SetMessage(message);
            }
        }

        public void SetStatus(ApiResult status, string message)
        {
            switch (status)
            {
                case (ApiResult.Success):
                    StatusCode = (int)ApiResult.Success;
                    Status = Constants.StatusSuccess;
                    break;
                case (ApiResult.Fail):
                    StatusCode = (int)ApiResult.Fail;
                    Status = Constants.Statusfail;
                    break;
                default:
                    break;
            }
        }

        public BaseResponse(ApiResult status)
        {
            SetStatus(status);
        }

        public BaseResponse(ApiResult status, string error = null)
        {
            SetStatus(status);

            if (!string.IsNullOrEmpty(error))
            {
                AddError(error);
            }
        }
    }
}