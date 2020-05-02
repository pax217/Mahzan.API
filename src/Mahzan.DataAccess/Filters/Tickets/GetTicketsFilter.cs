using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Filters.Tickets
{
    public class GetTicketsFilter
    {
        public Guid? TicketsId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
