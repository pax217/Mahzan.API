using System;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ICompaniesRepository: IRepositoryBase<Companies>
    {
        PagedList<Companies> Get(GetCompaniesFilter getCompaniesFilter);

        Companies Update(PutCompaniesDto putCompaniesDto);

        Companies Delete(DeleteCompaniesDto deleteCompaniesDto);
    }
}
