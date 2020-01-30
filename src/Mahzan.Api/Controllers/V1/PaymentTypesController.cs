using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.PaymentTypes;
using Mahzan.Business.Requests.PaymentTypes;
using Mahzan.Business.Results.PaymentTypes;
using Mahzan.DataAccess.DTO.PaymentTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PaymentTypesController : BaseController
    {
        readonly IPaymentTypesBusiness _paymentTypesBusiness;

        public PaymentTypesController(
            IMembersBusiness miembrosBusiness,
            IPaymentTypesBusiness paymentTypesBusiness
            ) : base(miembrosBusiness)
        {
            _paymentTypesBusiness = paymentTypesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostPaymentTypesRequest postPaymentTypesRequest)
        {

            PostPaymentTypesResult result = await _paymentTypesBusiness
                                                  .Add(new AddPaymentTypesDto {
                                                      Name = postPaymentTypesRequest.Name,
                                                      MembersId = MemberId
                                                  });

            return StatusCode(result.StatusCode, result);
        }
    }
}
