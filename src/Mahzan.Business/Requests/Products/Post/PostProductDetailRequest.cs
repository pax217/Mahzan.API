using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Products.Post
{
    public class PostProductDetailRequest
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
