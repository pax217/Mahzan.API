using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.PointOfSales
{
    public class PostPointOfSalesResult:Result
    {
        public Models.Entities.PointsOfSales PointOfSale { get; set; }
    }
}
