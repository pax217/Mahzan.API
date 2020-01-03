using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.Groups
{
    public class GetGroupsResult:Result
    {
        public PagedList<Models.Entities.Groups> Groups { get; set; }

        public Paging Paging { get; set; }
    }
}
