using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.DTO.Tickets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.Tickets
{
    public class PostTicketCloseSaleResult:Result
    {
        public Models.Entities.Tickets Ticket { get; set; }
    }
}
