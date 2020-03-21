using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ICompaniesRepository: IRepositoryBase<Companies>
    {
        Task<Companies> Add(AddCompaniesDto addCompaniesDto);

        Task<PagedList<Companies>> Get(GetCompaniesDto getCompaniesDto);

        Task<Companies> Update(PutCompaniesDto putCompaniesDto);

        Task<Companies> Delete(DeleteCompaniesDto deleteCompaniesDto);
    }
}
