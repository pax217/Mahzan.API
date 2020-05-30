using Mahzan.Business.Results._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.Tickets
{
    public class GetTicketToPrintResult:Result
    {
        public string Ticket { get; set; }
    }
}
