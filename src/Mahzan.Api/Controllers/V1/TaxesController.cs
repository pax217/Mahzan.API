using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Business.Requests.Taxes;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.DTO.Taxes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TaxesController : BaseController
    {
        readonly ITaxesBusiness _taxesBusiness;

        public TaxesController(
            IMembersBusiness miembrosBusiness,
            ITaxesBusiness taxesBusiness)
            : base(miembrosBusiness)
        {
            _taxesBusiness = taxesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostTaxesRequest postTaxesRequest)
        {
            PostTaxesResult result = await _taxesBusiness
                                            .Add(new AddTaxesDto
                                            {
                                                Name = postTaxesRequest.Name,
                                                TaxRate = postTaxesRequest.TaxRate,
                                                TaxType = postTaxesRequest.TaxType,
                                                TaxOption = postTaxesRequest.TaxOption,
                                                StoresIds = postTaxesRequest.StoresIds,
                                                MembersId = MemberId,
                                                AspNetUserId = AspNetUserId
                                            });

            return StatusCode(result.StatusCode, result);
        }
    }
}
