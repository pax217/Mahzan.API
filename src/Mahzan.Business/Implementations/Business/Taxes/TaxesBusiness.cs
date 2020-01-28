using System;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.DTO.Taxes;

namespace Mahzan.Business.Implementations.Business.Taxes
{
    public class TaxesBusiness: ITaxesBusiness
    {
        public TaxesBusiness()
        {
        }

        public Task<PostTaxesResult> Add(AddTaxesDto addTaxesDto)
        {
            throw new NotImplementedException();
        }
    }
}
