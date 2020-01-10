using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.PointOfSales
{
    public class GetPointsOfSalesResult:Result
    {
        public PagedList<Models.Entities.PointsOfSales> PointsOfSales { get; set; }
        public Paging Paging { get; set; }
    }
}
