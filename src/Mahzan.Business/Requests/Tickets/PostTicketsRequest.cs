using System;
using System.Collections.Generic;

namespace Mahzan.Business.Requests.Tickets
{
    public class PostTicketsRequest
    {

        public Guid StoresId { get; set; }

        public List<PostTicketDetailRequest> PostTicketDetailRequest { get; set; }
    }

    public class PostTicketDetailRequest
    {
        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

    }
}
