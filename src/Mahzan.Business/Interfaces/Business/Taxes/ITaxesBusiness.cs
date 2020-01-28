using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.DTO.Taxes;

namespace Mahzan.Business.Interfaces.Business.Taxes
{
    public interface ITaxesBusiness
    {
        Task<PostTaxesResult> Add(AddTaxesDto addTaxesDto);
    }
}
