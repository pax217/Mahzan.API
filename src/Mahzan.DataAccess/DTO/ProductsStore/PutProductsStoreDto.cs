using System;
namespace Mahzan.DataAccess.DTO.ProductsStore
{
    public class PutProductsStoreDto
    {
        public Guid ProductsStoreId { get; set; }
        public decimal? InStock { get; set; }
    }
}
