using Mahzan.Dapper.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Tickets.GetTicketToPrint
{
    public class GetTicketToPrintDto:BaseDto
    {
        public Guid TicketsId { get; set; }
    }
}
