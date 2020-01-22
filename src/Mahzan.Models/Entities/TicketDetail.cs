using System;
namespace Mahzan.Models.Entities
{
    public class TicketDetail
    {
        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        //Tickets
        public Guid TicketsId { get; set; }
        public Tickets Tickets { get; set; }
    }
}
