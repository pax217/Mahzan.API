using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Taxes;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.DataAccess.Filters.Taxes;

namespace Mahzan.Business.Interfaces.Business.Taxes
{
    public interface ITaxesBusiness
    {
        Task<PostTaxesResult> Add(CreateTaxDto insertTaxDto);

        Task<GetTaxesResult> GetWhere(GetTaxesDto getTaxesDto);
    }
}
