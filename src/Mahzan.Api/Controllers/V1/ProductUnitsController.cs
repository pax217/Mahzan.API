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
using Mahzan.DataAccess.Filters.ProductUnits;
using Mahzan.DataAccess.Paging;
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
                                                       MembersId = MembersId,
                                                       TableAuditEnum = TableAuditEnum.PRODUCT_UNITS_AUDIT
                                                    });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetProductUnits getProductUnits)
        {
            GetGetProductUnitsResult result = await _productUnitsBusiness
                                .Get(new GetProductUnitsDto
                                {
                                    Description = getProductUnits.Description,
                                    MembersId = MembersId
                                });

            result.Paging = new Paging()
            {
                TotalCount = result.ProductUnits.TotalCount,
                PageSize = result.ProductUnits.PageSize,
                CurrentPage = result.ProductUnits.CurrentPage,
                TotalPages = result.ProductUnits.TotalPages,
                HasNext = result.ProductUnits.HasNext,
                HasPrevious = result.ProductUnits.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutProductUnitsRequest putProductUnitsRequest)
        {
            PutProductUnitsResult result = await _productUnitsBusiness
                                            .Put(new PutProductUnitsDto()
                                            {
                                                ProductUnitsId = putProductUnitsRequest.ProductUnitsId,
                                                Abbreviation = putProductUnitsRequest.Abbreviation,
                                                Description = putProductUnitsRequest.Description,
                                                AspNetUserId = AspNetUserId,
                                                TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                            });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid ProductUnitsId)
        {
            DeleteProductUnitsResult result = await _productUnitsBusiness
                                               .Delete(new DeleteProductUnitsDto()
                                               {
                                                   ProductUnitsId = ProductUnitsId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }
    }
}
