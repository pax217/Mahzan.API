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
using Mahzan.DataAccess.Filters.ProductCategories;
using Mahzan.DataAccess.Paging;
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
                                                          MembersId = MembersId,
                                                          AspNetUserId = AspNetUserId,
                                                          TableAuditEnum = TableAuditEnum.PRODUCT_CATEGORIES_AUDIT
                                                      });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetProductCategoriesFilter getProductCategories)
        {
            GetProductCategoriesResult result = await _productCategoriesBusiness
                                .Get(new GetProductsCategoriesDto
                                {
                                    ProductCategoriesId = getProductCategories.ProductCategoriesId,
                                    Description = getProductCategories.Description,
                                    MembersId = MembersId
                                });

            result.Paging = new Paging()
            {
                TotalCount = result.ProductCategories.TotalCount,
                PageSize = result.ProductCategories.PageSize,
                CurrentPage = result.ProductCategories.CurrentPage,
                TotalPages = result.ProductCategories.TotalPages,
                HasNext = result.ProductCategories.HasNext,
                HasPrevious = result.ProductCategories.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutProductCategoriesRequest putProductCategoriesRequest)
        {
            PutProductCategoriesResult result = await _productCategoriesBusiness
                                            .Put(new PutProductCategoriesDto()
                                            {
                                                ProductCategoriesId = putProductCategoriesRequest.ProductCategoriesId,
                                                Description = putProductCategoriesRequest.Description,
                                                Color = putProductCategoriesRequest.Color,
                                                AspNetUserId = AspNetUserId,
                                                TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                            });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid productCategoriesId)
        {
            DeleteProductCategoriesResult result = await _productCategoriesBusiness
                                               .Delete(new DeleteProductsCategoriesDto()
                                               {
                                                   ProductCategoriesId = productCategoriesId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }
    }
}
