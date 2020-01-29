using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.ProductCategories
{
    public class PostProductCategoriesResult:Result
    {
        public Models.Entities.ProductCategories ProductCategory { get; set; }
    }
}
