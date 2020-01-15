using System;
namespace Mahzan.Business.Requests.Products
{
    public class PostProductsRequest
    {
        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public bool Active { get; set; }

        public Guid? ProductCategoryId { get; set; }

        public Guid ProductUnitId { get; set; }
    }
}
