using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Products
{
    public class AddProductsDto: BaseDto 
    {
        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public Guid? ProductCategoryId { get; set; }

        public Guid ProductUnitId { get; set; }
    }
}
