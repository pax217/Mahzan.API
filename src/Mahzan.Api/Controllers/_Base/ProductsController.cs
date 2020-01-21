using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Requests.Products;
using Mahzan.Business.Requests.Products_Store;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        readonly IProductsBusiness _productsBusiness;

        readonly IMapper _mapper;

        public ProductsController(
            IMembersBusiness miembrosBusiness,
            IProductsBusiness productsBusiness,
            IMapper mapper)
            :base(miembrosBusiness)
        {
            _productsBusiness = productsBusiness;

            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostProductsRequest postProductsRequest)
        {
            PostProductsResult result = await _productsBusiness
                                               .Add(new AddProductsDto
                                               {
                                                   SKU = postProductsRequest.SKU,
                                                   Barcode = postProductsRequest.Barcode,
                                                   Description = postProductsRequest.Description,
                                                   Price = postProductsRequest.Price,
                                                   Cost = postProductsRequest.Cost,
                                                   ProductCategoriesId = postProductsRequest.ProductCategoriesId,
                                                   ProductUnitsId = postProductsRequest.ProductUnitsId,
                                                   FollowInventory = postProductsRequest.FollowInventory,
                                                   AvailableInAllStores = postProductsRequest.AvailableInAllStores,
                                                   AddProductsStoreDto = _mapper.Map<List<AddProductsStoreDto>>(postProductsRequest.PostProductsStoreRequest),
                                                   AspNetUserId = AspNetUserId,
                                                   MemberId = MemberId,
                                                   TableAuditEnum = TableAuditEnum.PRODUCTS_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }
    }
}
