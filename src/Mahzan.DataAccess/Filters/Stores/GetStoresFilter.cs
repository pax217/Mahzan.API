using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Stores
{
    public class GetStoresFilter:FilterBase
    {
        public Guid? StoresId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid? CompaniesId { get; set; }
    }
}
