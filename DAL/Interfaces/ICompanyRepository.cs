using Model;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICompanyRepository
    {
        ResponseList<IEnumerable<Company>> GetCompanies(FilterBase filter);
        Task<Company> GetCompanyById(int id);
        Task<string> SetCompany(Company company);
        Task<int> DeleteCompany(int id);
    }
}
