using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Interfaces.Taxes
{
    public interface ITaxesDapper
    {
        Task<Guid> InsertAsync(CreateTaxDto insertTaxesDto);

        Task<Models.Entities.Taxes> GetByIdAsync(Guid taxesId);

        Task<PagedList<Models.Entities.Taxes>> GetWhereAsync(GetTaxesDto getTaxesDto);

        Task DeleteAsync(DeleteTaxDto insertTaxDto);

        Task UpdateAsync(UpdateTaxDto updateTaxDto);
    }
}
