using System;
namespace Mahzan.DataAccess.DTO.ProductsStore
{
    public class AddProductsStoreDto
    {
        public decimal Price { get; set; }

        public decimal? Cost { get; set; }

        public decimal? InStock { get; set; }

        public decimal? LowStock { get; set; }

        public decimal? OptimumStock { get; set; }

        public Guid StoresId { get; set; }

        public Guid ProductsId { get; set; }
    }
}
