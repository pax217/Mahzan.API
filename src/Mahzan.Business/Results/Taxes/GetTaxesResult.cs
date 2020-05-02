using Mahzan.Business.Results._Base;
using Mahzan.Dapper.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.Taxes
{
    public class GetTaxesResult:Result
    {
        public PagedList<Models.Entities.Taxes> Taxes { get; set; }

        public Paging Paging { get; set; }
    }
}
