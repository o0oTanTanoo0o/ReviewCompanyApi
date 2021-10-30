using Model;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompanyService
    {
        ResponseList<IEnumerable<Company>> GetCompanies(FilterBase filter);
        Task<Company> GetCompanyById(int id);
        Task<string> SetCompany(Company company);
        Task<int> DeleteCompany(int id);
    }
}
