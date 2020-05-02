using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Taxes;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITaxesRepository : IRepositoryBase<Taxes>
    {
        Taxes Add(AddTaxesDto addTaxesDto);

        Task <PagedList<Taxes>> GetWhere(GetTaxesDto getTaxesDto);
    }
}
