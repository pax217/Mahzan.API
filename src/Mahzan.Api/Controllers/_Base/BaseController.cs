using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers._Base
{
    [ApiController]
    public class BaseController : Controller
    {
        readonly IMembersBusiness _miembrosBusiness;

        public BaseController(IMembersBusiness miembrosBusiness)
        {
            _miembrosBusiness = miembrosBusiness;
        }

        public string UserName
        {
            get
            {
                return _miembrosBusiness
                        .Get(HttpContext.User.Claims.ToList()[0].Value).UserName;
            }
        }

        public Guid MembersId
        {
            get
            {
                

                Members member = _miembrosBusiness
                                 .Get(HttpContext.User.Claims.ToList()[0].Value);

                return member.MembersPatternId==null? member.MembersId: member.MembersPatternId.Value;
            }
        }

        public Guid AspNetUserId
        {
            get
            {
                return _miembrosBusiness
                        .Get(HttpContext.User.Claims.ToList()[0].Value).AspNetUsersId;
            }
        }
    }
}
