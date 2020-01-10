using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.PointOfSales
{
    public class PutPointsOfSalesRequest
    {
        [Required]
        public Guid PointOfSalesId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool? Active { get; set; }
    }
}
