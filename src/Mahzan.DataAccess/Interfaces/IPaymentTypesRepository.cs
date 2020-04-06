using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.PaymentTypes;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IPaymentTypesRepository: IRepositoryBase<PaymentTypes>
    {
        Task<PaymentTypes> Add(AddPaymentTypesDto addPaymentTypesDto);

        Task<PagedList<PaymentTypes>> Get(GetPaymentTypesDto getPaymentTypesDto);
    }
}
