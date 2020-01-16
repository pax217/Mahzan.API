using System;
using System.Collections.Generic;
using Mahzan.DataAccess.Filters.MenuItems;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IMenuItemsRepository: IRepositoryBase<Menu_Items>
    {
        List<Menu_Items> Get(GetMenuItemsFilter getMenuItemsFilter);
    }
}
