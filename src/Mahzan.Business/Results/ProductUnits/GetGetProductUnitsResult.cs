using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.ProductUnits
{
    public class GetGetProductUnitsResult:Result
    {
        public PagedList<Models.Entities.ProductUnits> ProductUnits { get; set; }

        public Paging Paging { get; set; }
    }
}
