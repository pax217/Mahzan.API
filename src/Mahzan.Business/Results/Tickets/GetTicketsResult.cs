using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.Tickets
{
    public class GetTicketsResult:Result
    {
        public PagedList<Models.Entities.Tickets> Tickets { get; set; }
    }
}
