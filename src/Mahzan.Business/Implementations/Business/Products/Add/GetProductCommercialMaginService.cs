using Mahzan.Business.Interfaces.Business.Products.Add;
using Mahzan.Business.Utils;
using Mahzan.DataAccess.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Business.Products.Add
{
    public class GetProductCommercialMaginService : IGetProductCommercialMaginService
    {
        public AddProductsDto GetCommercialMargin(AddProductsDto addProductsDto)
        {
            return new AddProductsDto
            {
                AddProductPhotoDto = addProductsDto.AddProductPhotoDto,
                AddProductDetailDto = new AddProductDetailDto 
                {
                    ProductCategoriesId = addProductsDto.AddProductDetailDto.ProductCategoriesId,
                    ProductUnitsId = addProductsDto.AddProductDetailDto.ProductUnitsId,
                    Barcode = addProductsDto.AddProductDetailDto.Barcode,
                    SKU = addProductsDto.AddProductDetailDto.SKU,
                    Description = addProductsDto.AddProductDetailDto.Description,
                    Price = addProductsDto.AddProductDetailDto.Price,
                    Cost = addProductsDto.AddProductDetailDto.Cost,
                    CommercialMargin = UtilsCommercialMargin
                                       .GetCommercialMargin(addProductsDto.AddProductDetailDto.Price,
                                                            addProductsDto.AddProductDetailDto.Cost),
                    CommercialMarginPercentaje = UtilsCommercialMargin
                                                 .GetCommercialMarginPercentaje(addProductsDto.AddProductDetailDto.Price,
                                                                                addProductsDto.AddProductDetailDto.Cost),
                    FollowInventory = addProductsDto.AddProductDetailDto.FollowInventory
                },
                MembersId = addProductsDto.MembersId,
                AspNetUserId = addProductsDto.AspNetUserId
            };
        }
    }
}
