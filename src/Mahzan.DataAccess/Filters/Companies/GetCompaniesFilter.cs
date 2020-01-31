using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Companies
{
    public class GetCompaniesFilter: FilterBase
    {
        public Guid? CompaniesId { get; set; }

        public string BusinessName { get; set; }

    }
}
