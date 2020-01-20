using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Products
{
    public class PostProductsRequest
    {
        public string SKU { get; set; }

        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Cost { get; set; }

        public Guid? ProductCategoriesId { get; set; }
        [Required]
        public Guid ProductUnitsId { get; set; }
    }
}
