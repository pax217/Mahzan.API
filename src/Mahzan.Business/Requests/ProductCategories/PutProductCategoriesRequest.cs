using System;
namespace Mahzan.Business.Requests.ProductCategories
{
    public class PutProductCategoriesRequest
    {
        public Guid ProductCategoriesId { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }
    }
}
