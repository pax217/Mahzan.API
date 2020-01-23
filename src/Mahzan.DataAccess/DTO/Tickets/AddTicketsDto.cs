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

        public Guid ProductsId { get; set; }
    }
}
