using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;
using Newtonsoft.Json;

namespace Mahzan.Business.Results.Tickets
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PostTicketsResult:Result
    {
        public Models.Entities.Tickets Ticket { get; set; }

        public List<Models.Entities.TicketDetail> TicketDetail { get; set; }
    }
}
