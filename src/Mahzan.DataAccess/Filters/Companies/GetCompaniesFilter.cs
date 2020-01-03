using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Companies
{
    public class GetCompaniesFilter: FilterBase
    {
        public string BusinessName { get; set; }

        public Guid? MemberId { get; set; }
    }
}
