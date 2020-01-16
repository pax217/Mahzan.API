using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business.Menu;
using Mahzan.Business.Results.Menu;
using Mahzan.DataAccess.Filters.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        readonly IMenuBusiness _menuBusiness;

        public MenuController(IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetMenuFilter getMenuFilter)
        {
            GetMenuResult result = await _menuBusiness
                                         .Get(getMenuFilter);

            return StatusCode(result.StatusCode, result);
        }
    }
}
