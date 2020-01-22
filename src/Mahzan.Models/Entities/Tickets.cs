using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Tickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        //TicketDetails
        public ICollection<TicketDetail> TicketDetail { get; set; }

        //Store
        public Stores StoresId { get; set; }
        public Stores Stores { get; set; }





    }
}
