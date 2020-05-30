using Mahzan.Business.Events.Tickets.GetTicketToPrint;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Tickets.GetTicketToPrint
{
    public interface IGetTicketToPrintEventHandler
    {
        Task<string> Handle(GetTicketToPrintEvent getTicketToPrintEvent);
    }
}
