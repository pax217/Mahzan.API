using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.ProductCategories
{
    public class GetProductCategoriesResult:Result
    {
        public PagedList<Models.Entities.ProductCategories> ProductCategories { get; set; }

        public Paging Paging { get; set; }
    }
}
