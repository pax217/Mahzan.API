using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.PointOfSales
{
    public class DeletePointsOfSalesDto:BaseDto
    {
        public Guid PointsOfSalesId { get; set; }
    }
}
