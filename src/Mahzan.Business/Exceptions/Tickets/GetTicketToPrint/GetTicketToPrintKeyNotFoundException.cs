using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Exceptions.Tickets.GetTicketToPrint
{
    public class GetTicketToPrintKeyNotFoundException : KeyNotFoundException
    {
        public GetTicketToPrintKeyNotFoundException(string message) : base(message)
        {
        }
    }
}
