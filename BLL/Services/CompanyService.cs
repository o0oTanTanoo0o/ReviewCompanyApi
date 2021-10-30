using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(
            ICompanyRepository companyRepository,
            ILogger<CompanyService> logger
            )
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public Task<int> DeleteCompany(int id)
        {
            try
            {
                return this._companyRepository.DeleteCompany(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Company>> GetCompanies(FilterBase filter)
        {
            try
            {
                return this._companyRepository.GetCompanies(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Company> GetCompanyById(int id)
        {
            try
            {
                return this._companyRepository.GetCompanyById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> SetCompany(Company company)
        {
            try
            {
                return this._companyRepository.SetCompany(company);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
