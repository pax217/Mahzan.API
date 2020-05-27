using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mahzan.Dapper.DTO.Products.CreateProduct
{
    public class CreateProductDetailDto
    {
        public Guid? ProductCategoriesId { get; set; }

        public Guid ProductUnitsId { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? Cost { get; set; }

        public decimal? CommercialMargin { get; set; }

        public decimal? CommercialMarginPercentaje { get; set; }

        public bool FollowInventory { get; set; }
    }
}
