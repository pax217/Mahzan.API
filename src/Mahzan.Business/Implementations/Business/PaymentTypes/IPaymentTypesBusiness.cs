using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.PaymentTypes;
using Mahzan.Business.Resources.Business.PaymentTypes;
using Mahzan.Business.Results.PaymentTypes;
using Mahzan.DataAccess.DTO.PaymentTypes;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.PaymentTypes
{
    public class PaymentTypesBusiness : IPaymentTypesBusiness
    {
        readonly IPaymentTypesRepository _paymentTypesRepository;

        public PaymentTypesBusiness(IPaymentTypesRepository paymentTypesRepository)
        {
            _paymentTypesRepository = paymentTypesRepository;
        }

        public async Task<PostPaymentTypesResult> Add(AddPaymentTypesDto addPaymentTypesDto)
        {
            PostPaymentTypesResult result = new PostPaymentTypesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddPaymentTypesResources.ResourceManager.GetString("Add_Title"),
                Message = AddPaymentTypesResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones de Tipos de Pago

                //Agrega Tipo de Pago
                result.PaymentTypes = await _paymentTypesRepository
                                            .Add(addPaymentTypesDto);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
