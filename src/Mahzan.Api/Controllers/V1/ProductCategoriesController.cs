using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.ProductCategories;
using Mahzan.Business.Requests.ProductCategories;
using Mahzan.Business.Results.ProductCategories;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductCategoriesController : BaseController
    {
        readonly IProductCategoriesBusiness _productCategoriesBusiness;

        public ProductCategoriesController(
            IMembersBusiness miembrosBusiness,
            IProductCategoriesBusiness productCategoriesBusiness
            ) : base(miembrosBusiness)
        {
            _productCategoriesBusiness = productCategoriesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostProductCategoriesRequest postProductCategoriesRequest)
        {
            PostProductCategoriesResult result = await _productCategoriesBusiness
                                                      .Add(new AddProductCategoriesDto
                                                      {
                                                          Description = postProductCategoriesRequest.Description,
                                                          Color = postProductCategoriesRequest.Color,
                                                          MembersId = MemberId,
                                                          AspNetUserId = AspNetUserId,
                                                          TableAuditEnum = TableAuditEnum.PRODUCT_CATEGORIES_AUDIT
                                                      });

            return StatusCode(result.StatusCode, result);
        }

    }
}
