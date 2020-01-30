using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Tickets
{
    public class PostTicketsRequest
    {
        [Required]
        public Guid StoresId { get; set; }
        [Required]
        public Guid PointsOfSalesId { get; set; }
        [Required]
        public Guid PaymentTypesId { get; set; }
        [Required]
        public List<PostTicketDetailRequest> PostTicketDetailRequest { get; set; }
    }

    public class PostTicketDetailRequest
    {
        public Guid ProductsId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
