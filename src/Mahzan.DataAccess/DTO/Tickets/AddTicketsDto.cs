using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Tickets
{
    public class AddTicketsDto:BaseDto
    {
        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        public int TotalProducts { get; set; }

        public string BarCode { get; set; }

        public Guid StoresId { get; set; }

        public Guid PointsOfSalesId { get; set; }

        public Guid PaymentTypesId { get; set; }

        public List<PostTicketDetailDto> PostTicketDetailDto { get; set; }

        public List<TicketDetailTaxesDto> TicketDetailTaxesDto { get; set; }
    }

    public class PostTicketDetailDto
    {
        public Guid ProductsId { get; set; }

        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }

    public class TicketDetailTaxesDto 
    {
        public decimal TaxRate { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public Guid ProductsId { get; set; }
        public Guid TaxesId { get; set; }
    }
}
