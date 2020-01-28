using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Filters.Companies;

namespace Mahzan.Business.Interfaces.Business.Companies
{
    public interface ICompaniesBusiness
    {
        Task<AddCompaniesResult> Add(AddCompaniesDto addCompaniesDto);
        Task<DeleteCompaniesResult> Delete(DeleteCompaniesDto addCompaniesDto);
        Task<PutCompaniesResult> Update(PutCompaniesDto addCompaniesDto);
        Task<GetCompaniesResult> Get(GetCompaniesDto getCompaniesDto);
    }
}
