using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Menu;
using Mahzan.DataAccess.Filters.Menu;

namespace Mahzan.Business.Interfaces.Business.Menu
{


    public interface IMenuBusiness
    {
        Task<GetMenuResult> Get(GetMenuFilter getMenuFilter);
    }
}
