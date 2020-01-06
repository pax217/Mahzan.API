using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.Stores
{
    public class GetStoresResult:Result
    {
        public PagedList<Models.Entities.Stores> Stores { get; set; }

        public Paging Paging { get; set; }
    }
}
