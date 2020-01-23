using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Tickets
{
    public class AddTicketsDto:BaseDto
    {
        public Guid StoresId { get; set; }

        public List<PostTicketDetailDto> PostTicketDetailDto { get; set; }
    }

    public class PostTicketDetailDto
    {
        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
