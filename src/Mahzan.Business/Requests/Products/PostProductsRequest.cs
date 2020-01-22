using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Requests.Products_Store;
using Mahzan.DataAccess.DTO.ProductsStore;

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

        public bool FollowInventory { get; set; }

        public bool AvailableInAllStores { get; set; }

        public List<PostProductsStoreRequest> PostProductsStoreRequest { get; set; }

        public Guid? ProductCategoriesId { get; set; }
        [Required]
        public Guid ProductUnitsId { get; set; }
    }
}
