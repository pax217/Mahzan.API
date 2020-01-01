using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.Grupos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GruposController : BaseController
    {


        public GruposController(IMembersBusiness miembrosBusiness)
            : base(miembrosBusiness)
        {
 
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(AddGrupoRequest addGrupoRequest)
        {
            addGrupoRequest.MiembroId = MiembroId;

            return Ok();
        }
    }
}
