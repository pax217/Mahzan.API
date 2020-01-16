using System;
using System.Collections.Generic;
using System.Linq;
using Mahzan.DataAccess.Filters.MenuItems;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mahzan.DataAccess.Implementations
{
    public class MenuItemsRepository: RepositoryBase<Menu_Items>, IMenuItemsRepository
    {
        public MenuItemsRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public List<Menu_Items> Get(GetMenuItemsFilter getMenuItemsFilter)
        {
            List<Menu_Items> result = new List<Menu_Items>();

            result = (from m in _context.Set<Menu_Items>()
                                .Include(m => m.Menu_SubItems)
                      where m.Id == getMenuItemsFilter.MenuItemId
                      select m)
                      .ToList();

            return result;
        }
    }
}
