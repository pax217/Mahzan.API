using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.PointsOfSales
{
    public class GetPointsOfSalesFilter:FilterBase
    {
        public Guid? StoresId { get; set; }
    }
}
