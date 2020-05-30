using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Tickets.GetTicketToPrint
{
    public class GetTicketToPrintEvent:BaseEvent
    {
        public Guid  TicketsId { get; set; }
    }
}
