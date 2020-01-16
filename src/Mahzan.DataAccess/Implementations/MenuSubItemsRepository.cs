using System;
using System.Collections.Generic;
using Mahzan.DataAccess.Filters.MenuSubItems;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class MenuSubItemsRepository: RepositoryBase<Menu_SubItems>, IMenuSubItemsRepository
    {
        public MenuSubItemsRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
