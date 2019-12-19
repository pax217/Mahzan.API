using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers._Base
{
    [ApiController]
    public class BaseController : Controller
    {
        readonly IMiembrosBusiness _miembrosBusiness;

        public BaseController(IMiembrosBusiness miembrosBusiness)
        {
            _miembrosBusiness = miembrosBusiness;
        }

        public string UserName
        {
            get
            {
                return HttpContext.User.Claims.ToList()[0].Value;
            }
        }

        public Guid MiembroId
        {
            get
            {
                return _miembrosBusiness
                        .Get(UserName);
            }
        }
    }
}
