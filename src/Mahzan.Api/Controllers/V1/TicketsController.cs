using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Requests.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TicketsController : BaseController
    {
        readonly ITicketsBusiness _ticketsBusiness;

        public TicketsController(
            IMembersBusiness miembrosBusiness,
            ITicketsBusiness ticketsBusiness)
            : base(miembrosBusiness)
        {

            _ticketsBusiness = ticketsBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostTicketsRequest postTicketsRequest)
        {
            PostTicketsResult result = await _ticketsBusiness
                                              .Add(new AddTicketsDto
                                              {
                                                  StoresId = postTicketsRequest.StoresId,
                                                  PostTicketDetailDto = postTicketsRequest.PostTicketDetailRequest
                                                                                          .Select(p => new PostTicketDetailDto {
                                                                                              Quantity = p.Quantity,
                                                                                              ProductsId = p.ProductsId
                                                                                          })
                                                                                          .ToList(),
                                                  AspNetUserId = AspNetUserId,
                                                  MemberId = MemberId
                                              });

            return StatusCode(result.StatusCode, result);
        }
    }
}
