using System;
using Mahzan.Business.Results._Base;
using Mahzan.Dapper.Paging;

namespace Mahzan.Business.Results.Clients
{
    public class GetClientsResult:Result
    {
        public PagedList<Models.Entities.Clients> Clients { get; set; }

        public Paging Paging;
    }
}
