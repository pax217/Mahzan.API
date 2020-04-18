using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.ProductsStore;
using Mahzan.Business.Requests.Products_Store;
using Mahzan.Business.Results.ProductsStore;
using Mahzan.DataAccess.DTO.ProductsStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsStoreController : BaseController
    {
        private readonly IProductsStoreBusiness _productsStoreBusiness;

        public ProductsStoreController(
            IMembersBusiness membersBusiness,
            IProductsStoreBusiness productsStoreBusiness)
            : base(membersBusiness)
        {
            _productsStoreBusiness = productsStoreBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostProductsStoreRequest postProductsStoreRequest)
        {
            PostProductsStoreResult result = await _productsStoreBusiness
                                          .Add(new AddProductsStoreDto { 
                                            ProductsStoreDto = postProductsStoreRequest
                                                               .ProductsStoreRequest
                                                               .Select(ps => new ProductsStoreDto { 
                                                                   Price = ps.Price,
                                                                   Cost = ps.Cost,
                                                                   InStock = ps.InStock,
                                                                   LowStock = ps.LowStock,
                                                                   OptimumStock = ps.OptimumStock,
                                                                   StoresId = ps.StoresId,
                                                                   ProductsId = ps.ProductsId
                                                               })
                                                               .ToList(),
                                            MembersId = MembersId,
                                            AspNetUserId = AspNetUserId
                                          });

            return StatusCode(result.StatusCode, result);
        }
    }
}