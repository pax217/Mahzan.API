using System;
using Mahzan.DataAccess.Filters.Menu;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IMenuRepository: IRepositoryBase<Menu>
    {
        PagedList<Menu> Get(GetMenuFilter getMenuFilter);
    }
}
