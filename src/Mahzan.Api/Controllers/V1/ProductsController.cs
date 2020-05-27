using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Api.Commands.Products.CreateProduct;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exeptions;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Events.Products.CreateProduct;
using Mahzan.Business.EventsHandlers.Products.CreateProduct;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Requests.Products.Post;
using Mahzan.Business.Results._Base;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Paging;
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

        private readonly ICreateProductEventHandler _createProductEventHandler;

        public ProductsController(
            IMembersBusiness miembrosBusiness,
            IProductsBusiness productsBusiness,
            ICreateProductEventHandler createProductEventHandler,
            IMapper mapper)
            : base(miembrosBusiness)
        {

            _productsBusiness = productsBusiness;

            _createProductEventHandler = createProductEventHandler;

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Post(CreateProductCommand createProductCommand)
        {
            CreateProductResult result = new CreateProductResult
            {
                IsValid= true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = $"Crea nuevo producto",
                Message = $"Se ha creado correctamente el producto {createProductCommand.CreateProductDetailCommand.Description}.",
            }; 

            try
            {
                CreateProductEvent createProductEvent = new CreateProductEvent
                {
                    CreateProductDetailEvent = new CreateProductDetailEvent
                    {
                        ProductCategoriesId = createProductCommand.CreateProductDetailCommand.ProductCategoriesId,
                        ProductUnitsId = createProductCommand.CreateProductDetailCommand.ProductUnitsId,
                        SKU = createProductCommand.CreateProductDetailCommand.SKU,
                        Barcode = createProductCommand.CreateProductDetailCommand.Barcode,
                        Description = createProductCommand.CreateProductDetailCommand.Description,
                        Price = createProductCommand.CreateProductDetailCommand.Price,
                        Cost = createProductCommand.CreateProductDetailCommand.Cost,
                        FollowInventory = createProductCommand.CreateProductDetailCommand.FollowInventory
                    },
                    CreateProductPhotoEvent = new CreateProductPhotoEvent
                    {
                        Title = createProductCommand.CreateProductPhotoCommand.Title,
                        DateTime = DateTime.Now,
                        MIMEType = createProductCommand.CreateProductPhotoCommand.MIMEType,
                        Base64 = createProductCommand.CreateProductPhotoCommand.Base64
                    },
                    CreateProductTaxesEvent = createProductCommand.CreateProductTaxesCommand != null ?
                                                createProductCommand.CreateProductTaxesCommand
                                                .Select(p => new CreateProductTaxesEvent
                                                {
                                                    TaxesId = p.TaxesId,
                                                    TaxRate = p.TaxRate
                                                })
                                                .ToList()
                                                : null,
                    AspNetUserId = AspNetUserId,
                    MembersId = MembersId,
                    TableAuditEnum = TableAuditEnum.PRODUCTS_AUDIT
                };

                result.ProductsId= await _createProductEventHandler
                    .Handle(createProductEvent);
            }
            catch (InvalidOperationException ex)
            {
                throw new ServiceInvalidOperationException(ex);
            }

            return Ok(result);
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetProductsFilter getProductsFilter)
        {
            GetProductsResult result = await _productsBusiness
                                             .Get(new GetProductsDto
                                             {
                                                 ProductsId = getProductsFilter.ProductsId,
                                                 Barcode = getProductsFilter.Barcode,
                                                 MembersId = MembersId
                                             });

            result.Paging = new Paging()
            {
                TotalCount = result.Products.TotalCount,
                PageSize = result.Products.PageSize,
                CurrentPage = result.Products.CurrentPage,
                TotalPages = result.Products.TotalPages,
                HasNext = result.Products.HasNext,
                HasPrevious = result.Products.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid productsId)
        {
            DeleteProductsResult result = await _productsBusiness
                                               .Delete(new DeleteProductsDto()
                                               {
                                                   ProductsId = productsId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }
    }
}
