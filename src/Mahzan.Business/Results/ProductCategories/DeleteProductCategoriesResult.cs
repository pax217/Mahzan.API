using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.ProductCategories
{
    public class DeleteProductCategoriesResult:Result
    {
        public Models.Entities.ProductCategories ProductCategories { get; set; }
    }
}
