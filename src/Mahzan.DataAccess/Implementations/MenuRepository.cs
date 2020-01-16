using System;
using Mahzan.DataAccess.Filters.Menu;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class MenuRepository: RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Menu> Get(GetMenuFilter getMenuFilter)
        {
            throw new NotImplementedException();
        }
    }
}
