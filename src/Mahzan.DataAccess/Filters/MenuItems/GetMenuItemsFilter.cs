using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.MenuItems
{
    public class GetMenuItemsFilter: FilterBase
    {
        public Guid MenuItemId { get; set; }
    }
}
