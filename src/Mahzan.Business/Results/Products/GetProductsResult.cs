using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.Products
{
    public class GetProductsResult: Result 
    {
        public PagedList<Models.Entities.Products> Products { get; set; }
    }
}
