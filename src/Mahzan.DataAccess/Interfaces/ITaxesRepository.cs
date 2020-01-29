using System;
using Mahzan.DataAccess.DTO.Taxes;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITaxesRepository : IRepositoryBase<Taxes>
    {
        Taxes Add(AddTaxesDto addTaxesDto);

        PagedList<Taxes> Get(GetTaxesDto getTaxesDto);
    }
}
