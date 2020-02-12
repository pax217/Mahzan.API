using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mahzan.DataAccess.DTO._Base;
using Mahzan.DataAccess.DTO.ProductsStore;

namespace Mahzan.DataAccess.DTO.Products
{
    public class AddProductsDto: BaseDto 
    {
        public AddProductPhotoDto AddProductPhotoDto { get; set; }

        public AddProductDetailDto AddProductDetailDto { get; set; }
    }

    public class AddProductPhotoDto
    {

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }

        public Guid ProductsId { get; set; }

    }

    public class AddProductDetailDto
    {

        public Guid? ProductCategoriesId { get; set; }
        [Required]
        public Guid ProductUnitsId { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? Cost { get; set; }

    }
}
