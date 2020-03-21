using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Business.Companies
{
    public interface ICompaniesRepositories
    {
        Task<Models.Entities.Companies> AddCompany(AddCompaniesDto addCompaniesDto);

        Task<PagedList<Models.Entities.Companies>> GetCompanies(GetCompaniesDto getCompaniesDto);

        Task<Models.Entities.Companies> UpdateCompany(PutCompaniesDto putCompaniesDto);

        Task<Models.Entities.Companies> DeleteCompany(DeleteCompaniesDto deleteCompaniesDto);
    }
}
