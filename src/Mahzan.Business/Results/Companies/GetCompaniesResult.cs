using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.Companies
{
    public class GetCompaniesResult : Result
    {
        public PagedList<Models.Entities.Companies> Companies { get; set; }
        public Paging Paging { get; set; }
    }
}
