using System;
namespace Mahzan.Business.Requests.Products_Store
{
    public class PostProductsStoreRequest
    {
        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public decimal InStock { get; set; }

        public decimal LowStock { get; set; }

        public decimal OptimumStock { get; set; }

        public Guid StoreId { get; set; }
    }
}
