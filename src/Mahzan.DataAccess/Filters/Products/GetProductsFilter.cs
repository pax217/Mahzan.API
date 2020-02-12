using System;
namespace Mahzan.DataAccess.Filters.Products
{
    public class GetProductsFilter
    {
        public Guid? ProductsId { get; set; }

        public string Barcode { get; set; }
    }
}
