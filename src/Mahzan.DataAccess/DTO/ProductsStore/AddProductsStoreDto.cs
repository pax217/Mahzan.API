using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;

namespace Mahzan.DataAccess.DTO.ProductsStore
{
    public class AddProductsStoreDto:BaseDto
    {
        public List<ProductsStoreDto> ProductsStoreDto { get; set; }
    }

    public class ProductsStoreDto 
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
