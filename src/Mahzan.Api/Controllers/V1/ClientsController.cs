using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Clients;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.Clients;
using Mahzan.Business.Results.Clients;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Filters.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientsController : BaseController
    {
        readonly IClientsBusiness _clientsBusiness;

        public ClientsController(
            IMembersBusiness miembrosBusiness,
            IClientsBusiness clientsBusiness
            ) : base(miembrosBusiness)
        {
            _clientsBusiness = clientsBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostClientsRequest postClientsRequest)
        {
            PostClientsResult result = await _clientsBusiness
                                                .Add(new AddClientsDto {
                                                    Name = postClientsRequest.Name,
                                                    Email = postClientsRequest.Email,
                                                    Phone = postClientsRequest.Phone,
                                                    Notes = postClientsRequest.Notes,
                                                    AspNetUserId = AspNetUserId,
                                                    MembersId = MembersId
                                                });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetClientsFilter getClientsFilter)
        {
            GetClientsResult result = await _clientsBusiness
                                            .Get(new GetClientsDto {
                                                Name = getClientsFilter.Name
                                            });

            return StatusCode(result.StatusCode, result);
        }
    }
}
