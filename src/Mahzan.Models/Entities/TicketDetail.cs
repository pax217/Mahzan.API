using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class TicketDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TicketDetailId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        //Tickets
        public Guid TicketsId { get; set; }
        public Tickets Tickets { get; set; }
    }
}
