using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Business.Companies
{
    public class CompaniesRepositories : ICompaniesRepositories
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompaniesRepositories(
            ICompaniesRepository companiesRepository) 
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<Models.Entities.Companies> AddCompany(AddCompaniesDto addCompaniesDto)
        {
            return await _companiesRepository
                         .Add(addCompaniesDto);
        }

        public async Task<Models.Entities.Companies> DeleteCompany(DeleteCompaniesDto deleteCompaniesDto)
        {
            return await _companiesRepository
                         .Delete(deleteCompaniesDto);
        }

        public async Task<PagedList<Models.Entities.Companies>> GetCompanies(GetCompaniesDto getCompaniesDto)
        {
            return await _companiesRepository
                         .Get(getCompaniesDto);
        }

        public async Task<Models.Entities.Companies> UpdateCompany(PutCompaniesDto putCompaniesDto)
        {
            return await _companiesRepository
                         .Update(putCompaniesDto);
        }
    }
}
