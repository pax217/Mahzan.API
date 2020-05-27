using Mahzan.Business.Events.Products.CreateProduct;
using Mahzan.Business.Utils;
using Mahzan.Business.Validators.Products.CreateProduct;
using Mahzan.Dapper.DTO.Products.CreateProduct;
using Mahzan.Dapper.Repositories.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Products.CreateProduct
{
    public class CreateProductEventHandler : ICreateProductEventHandler
    {
        private readonly ICreateProductRepository _createProductRepository;

        private readonly ICreateProductValidator _createProductValidator;

        public CreateProductEventHandler(
            ICreateProductRepository createProductRepository, 
            ICreateProductValidator createProductValidator)
        {
            _createProductRepository = createProductRepository;
            _createProductValidator = createProductValidator;
        }

        public async Task Handle(CreateProductEvent createProductEvent)
        {
            //Validaciones de producto
            await _createProductValidator.Hanlde(createProductEvent);

            //Calcula margen comercial
            HandlerCommercialMargin(createProductEvent.CreateProductDetailEvent);

            //Inserta en Repositorio
            await _createProductRepository
                .Handle(new CreateProductDto
                {
                    CreateProductDetailDto = new CreateProductDetailDto
                    {
                        ProductCategoriesId = createProductEvent.CreateProductDetailEvent.ProductCategoriesId,
                        ProductUnitsId = createProductEvent.CreateProductDetailEvent.ProductUnitsId,
                        SKU = createProductEvent.CreateProductDetailEvent.SKU,
                        Barcode = createProductEvent.CreateProductDetailEvent.Barcode,
                        Description = createProductEvent.CreateProductDetailEvent.Description,
                        Price = createProductEvent.CreateProductDetailEvent.Price,
                        Cost = createProductEvent.CreateProductDetailEvent.Cost,
                        FollowInventory = createProductEvent.CreateProductDetailEvent.FollowInventory,
                        CommercialMargin = createProductEvent.CreateProductDetailEvent.CommercialMargin,
                        CommercialMarginPercentaje = createProductEvent.CreateProductDetailEvent.CommercialMarginPercentaje
                    },
                    CreateProductPhotoDto = new CreateProductPhotoDto {
                        Title = createProductEvent.CreateProductPhotoEvent.Title,
                        DateTime = DateTime.Now,
                        MIMEType = createProductEvent.CreateProductPhotoEvent.MIMEType,
                        Base64 = createProductEvent.CreateProductPhotoEvent.Base64
                    },
                    CreateProductTaxesDto = createProductEvent
                                            .CreateProductTaxesEvent
                                            .Select(p => new CreateProductTaxesDto {
                                                TaxesId = p.TaxesId,
                                                TaxRate = p.TaxRate
                                            })
                                            .ToList(),
                    AspNetUserId = createProductEvent.AspNetUserId,
                    MembersId = createProductEvent.MembersId,
                    TableAuditEnum = createProductEvent.TableAuditEnum
                });

        }

        private void HandlerCommercialMargin(CreateProductDetailEvent createProductDetailEvent) 
        {
            //Comercial Margin
            createProductDetailEvent.CommercialMargin = UtilsCommercialMargin
                .GetCommercialMargin(
                createProductDetailEvent.Price,
                createProductDetailEvent.Cost);

            //Comerical Margin Percentaje
            createProductDetailEvent.CommercialMarginPercentaje = UtilsCommercialMargin
                .GetCommercialMarginPercentaje(
                createProductDetailEvent.Price,
                createProductDetailEvent.Cost);

        }
    }
}
