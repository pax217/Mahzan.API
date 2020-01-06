using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Stores
{
    public class GetStoresFilter:FilterBase
    {
        public Guid StoreId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid CompanyId { get; set; }
    }
}
