using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Tickets
{
    public class GetTicketsDto:BaseDto
    {
        public Guid? TicketsId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
