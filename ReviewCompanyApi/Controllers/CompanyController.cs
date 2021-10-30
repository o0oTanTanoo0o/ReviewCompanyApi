using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewCompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(
             ICompanyService companyService
            )
        {
            this._companyService = companyService;
        }

        [HttpGet]
        public BaseResponse<ResponseList<IEnumerable<Company>>> GetCompanies([FromQuery] FilterBase search)
        {
            try
            {
                ResponseList<IEnumerable<Company>> result = _companyService.GetCompanies(search);
                return new BaseResponse<ResponseList<IEnumerable<Company>>>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ResponseList<IEnumerable<Company>>>(ApiResult.Success, null, ex.Message, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BaseResponse<Company>> GetCompanyById(int id)
        {
            try
            {
                Company result = await _companyService.GetCompanyById(id);
                return new BaseResponse<Company>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Company>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<string>> SetCompany([FromBody] Company company)
        {
            try
            {
                string result = await _companyService.SetCompany(company);
                return new BaseResponse<string>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(ApiResult.Fail, null, ex.Message, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<int>> DeleteCompany(int id)
        {
            try
            {
                int result = await _companyService.DeleteCompany(id);
                return new BaseResponse<int>(ApiResult.Success, result, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(ApiResult.Fail, -1, ex.Message, ex.Message);
            }
        }
    }
}
