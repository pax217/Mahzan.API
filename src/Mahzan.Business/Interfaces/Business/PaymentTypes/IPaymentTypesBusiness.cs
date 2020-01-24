using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.PaymentTypes;
using Mahzan.DataAccess.DTO.PaymentTypes;

namespace Mahzan.Business.Interfaces.Business.PaymentTypes
{
    public interface IPaymentTypesBusiness
    {
        Task<PostPaymentTypesResult> Add(AddPaymentTypesDto addPaymentTypesDto);
    }
}
