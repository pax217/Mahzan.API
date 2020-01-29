using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.DTO.Taxes;

namespace Mahzan.Business.Interfaces.Validations.Taxes
{
    public interface IAddTaxesValidations
    {
        Task<PostTaxesResult> AddTaxesValid(AddTaxesDto addTaxesDto);
    }
}
