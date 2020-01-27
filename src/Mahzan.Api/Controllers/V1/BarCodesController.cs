using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.BarCodes;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.BarCodes;
using Mahzan.Business.Results.BarCodes;
using Mahzan.DataAccess.DTO.BarCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BarCodesController : BaseController
    {
        readonly IBarCodesBusiness _barCodesBusiness;

        public BarCodesController(
           IMembersBusiness miembrosBusiness,
           IBarCodesBusiness barCodesBusiness ) : base(miembrosBusiness)
        {
            _barCodesBusiness = barCodesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostBarCodesRequest postBarCodesRequest)
        {

            PostBarCodesResult result = await _barCodesBusiness
                                              .Create(new CreateBarCodesDto {
                                                  ProductsIds  = postBarCodesRequest.ProductsIds
                                              });


            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(result.FileStream, "application/pdf");

            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;

        }
    }
}
