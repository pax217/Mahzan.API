using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.PointOfSales
{
    public class AddPointsOfSalesDto:BaseDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid StoresId { get; set; }
    }
}
