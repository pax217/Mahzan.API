using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.PointOfSales
{
    public class PostPointOfSalesRequest
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public bool? Active { get; set; }
        [Required]
        public Guid StoreId { get; set; }
    }
}
