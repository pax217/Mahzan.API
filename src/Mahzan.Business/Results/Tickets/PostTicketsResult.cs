using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Tickets
{
    public class PostTicketsResult:Result
    {
        public Models.Entities.Tickets Ticket { get; set; }

        public List<Models.Entities.TicketDetail> TicketDetail { get; set; }
    }
}
