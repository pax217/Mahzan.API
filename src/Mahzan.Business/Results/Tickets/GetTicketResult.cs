using Mahzan.Business.Results._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.Tickets
{
    public class GetTicketResult:Result
    {
        public Models.Entities.Tickets Ticket { get; set; }
    }
}
