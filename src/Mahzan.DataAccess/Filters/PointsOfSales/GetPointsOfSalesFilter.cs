using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.PointsOfSales
{
    public class GetPointsOfSalesFilter:FilterBase
    {
        public Guid? PointsOfSalesId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid? StoresId { get; set; }
    }
}
