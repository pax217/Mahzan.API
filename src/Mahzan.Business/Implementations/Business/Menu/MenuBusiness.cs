using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Menu;
using Mahzan.Business.Resources.Business.Menu;
using Mahzan.Business.Results.Menu;
using Mahzan.DataAccess.Filters.Menu;
using Mahzan.DataAccess.Filters.MenuItems;
using Mahzan.DataAccess.Interfaces;
using static Mahzan.Business.Results.Menu.Items;

namespace Mahzan.Business.Implementations.Business.Menu
{
    public class MenuBusiness: IMenuBusiness
    {
        readonly IMenuRepository _menuRepository;

        readonly IMenuItemsRepository _menuItemsRepository;

        readonly IMenuSubItemsRepository _menuSubItemsRepository;

        public MenuBusiness(
            IMenuRepository menuRepository,
            IMenuItemsRepository menuItemsRepository,
            IMenuSubItemsRepository menuSubItemsRepository)
        {
            _menuRepository = menuRepository;

            _menuItemsRepository = menuItemsRepository;

            _menuSubItemsRepository = menuSubItemsRepository;
        }

        public async Task<GetMenuResult> Get(GetMenuFilter getMenuFilter)
        {
            GetMenuResult result = new GetMenuResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetMenuResources.ResourceManager.GetString("Get_Title"),
                Message = GetMenuResources.ResourceManager.GetString("Get_200_SUCCESS_Message"),
            };

            List<Models.Entities.Menu> Menus = new List<Models.Entities.Menu>();
            result.Aside = new Aside();
            result.Aside.Items = new List<Items>();

            try
            {
                //Busca los Menus del Rol de Usuario
                Menus = _menuRepository
                        .Get(x => x.RoleId == getMenuFilter.RoleId);

                foreach (var menu in Menus)
                {
                    List<Models.Entities.Menu_Items> menu_Items = _menuItemsRepository
                                                             .Get(new GetMenuItemsFilter
                                                             {
                                                                 MenuItemId = menu.MenuItemId
                                                             });

                    if (menu_Items.Any())
                    {

                        foreach (var menu_Item in menu_Items)
                        {
                            List<SubMenu> subMenu = new List<SubMenu>();

                            foreach (var enu_SubItem in menu_Item.Menu_SubItems)
                            {
                                subMenu.Add(new SubMenu
                                {
                                    Title = enu_SubItem.Title,
                                    Page = enu_SubItem.Page
                                });
                            }

                            result.Aside.Items.Add(new Items
                            {
                                Section = menu_Item.Section,
                                Title = menu_Item.Title,
                                Icon = menu_Item.Icon,
                                Bullet = menu_Item.Bullet,
                                Page = menu_Item.Page,
                                Root = menu_Item.Root,
                                SubMenu = subMenu
                            });
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
