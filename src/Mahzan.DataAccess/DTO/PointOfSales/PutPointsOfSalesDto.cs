using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.PointOfSales
{
    public class PutPointsOfSalesDto:BaseDto
    {
        public Guid PointOfSalesId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool? Active { get; set; }
    }
}
