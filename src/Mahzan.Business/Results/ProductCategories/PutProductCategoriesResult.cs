using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.ProductCategories
{
    public class PutProductCategoriesResult:Result
    {
        public Models.Entities.ProductCategories ProductCategories { get; set; }
    }
}
