using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Tickets
{
    public class PostTicketCalculationRequest
    {
        [Required]
        public Guid StoresId { get; set; }
        [Required]
        public Guid PointsOfSalesId { get; set; }
        [Required]
        public Guid PaymentTypesId { get; set; }

        public Guid? ClientsId { get; set; }

        public decimal? CashPayment { get; set; }

        [Required]
        public List<PostTicketCalculationDetailRequest> PostTicketCalculationDetailRequest { get; set; }
    }

    public class PostTicketCalculationDetailRequest
    {
        public Guid ProductsId { get; set; }

        public int Quantity { get; set; }

    }
}
