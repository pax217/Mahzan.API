using Mahzan.Dapper.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Products.CreateProduct
{
    public class CreateProductDto:BaseDto
    {
        public CreateProductDetailDto CreateProductDetailDto { get; set; }

        public CreateProductPhotoDto CreateProductPhotoDto { get; set; }

        public List<CreateProductTaxesDto> CreateProductTaxesDto { get; set; }
    }
}
