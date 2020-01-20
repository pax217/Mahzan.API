using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.ProductCategories;
using Mahzan.Business.Interfaces.Business.ProductUnits;
using Mahzan.Business.Requests.ProductUnits;
using Mahzan.Business.Results.ProductUnits;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.DataAccess.DTO.ProductUnits;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductUnitsController : BaseController
    {
        readonly IProductUnitsBusiness _productUnitsBusiness ;

        public ProductUnitsController(
            IMembersBusiness miembrosBusiness,
            IProductUnitsBusiness productUnitsBusiness)
            : base(miembrosBusiness)
        {
            _productUnitsBusiness = productUnitsBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostProductUnitsRequest postProductUnitsRequest)
        {
            PostProductUnitsResult result = await _productUnitsBusiness
                                                    .Add(new AddProductUnitsDto
                                                    {
                                                       Abbreviation = postProductUnitsRequest.Abbreviation,
                                                       Description = postProductUnitsRequest.Description,
                                                       AspNetUserId = AspNetUserId,
                                                       MemberId = MemberId,
                                                       TableAuditEnum = TableAuditEnum.PRODUCT_UNITS_AUDIT
                                                    });

            return StatusCode(result.StatusCode, result);
        }
    }
}
