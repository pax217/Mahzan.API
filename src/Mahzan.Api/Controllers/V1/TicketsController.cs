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
using Mahzan.DataAccess.Filters.Tickets;
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
        [HttpPost("ticket-calculation")]
        public async Task<IActionResult> TicketCalculation(PostTicketCalculationRequest postTicketsRequest)
        {
            PostTicketCalculationResult result = await _ticketsBusiness
                                              .Calculate(new TicketCalculationDto
                                              {
                                                  StoresId = postTicketsRequest.StoresId,
                                                  PointsOfSalesId = postTicketsRequest.PointsOfSalesId,
                                                  PaymentTypesId = postTicketsRequest.PaymentTypesId,
                                                  PostTicketCalculationDetailDto = postTicketsRequest
                                                                                   .PostTicketCalculationDetailRequest
                                                                                   .Select(p => new PostTicketCalculationDetailDto
                                                                                   {
                                                                                       ProductsId = p.ProductsId,
                                                                                       Quantity = p.Quantity,
                                                                                   })
                                                                                   .ToList(),
                                                  AspNetUserId = AspNetUserId,
                                                  MembersId = MembersId
                                              });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("ticket-close-sale")]
        public async Task<IActionResult> TicketCloseSale(PostTicketCalculationRequest postTicketCalculationRequest)
        {
            PostTicketCloseSaleResult result = await _ticketsBusiness
                                              .CloseSale(new TicketCalculationDto
                                              {
                                                  StoresId = postTicketCalculationRequest.StoresId,
                                                  PointsOfSalesId = postTicketCalculationRequest.PointsOfSalesId,
                                                  PaymentTypesId = postTicketCalculationRequest.PaymentTypesId,
                                                  CashPayment = postTicketCalculationRequest.CashPayment,
                                                  PostTicketCalculationDetailDto = postTicketCalculationRequest
                                                                                   .PostTicketCalculationDetailRequest
                                                                                   .Select(p => new PostTicketCalculationDetailDto
                                                                                   {
                                                                                       ProductsId = p.ProductsId,
                                                                                       Quantity = p.Quantity,
                                                                                   })
                                                                                   .ToList(),
                                                  AspNetUserId = AspNetUserId,
                                                  MembersId = MembersId
                                              });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetWhereFilter([FromQuery]GetTicketsFilter getTicketsFilter)
        {
            GetTicketsResult result = await _ticketsBusiness
                                           .GetAll(new GetTicketsDto
                                           {
                                               CreatedAt = getTicketsFilter.CreatedAt,
                                               MembersId = MembersId
                                           });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{ticketsId}")]
        public async Task<IActionResult> GetById(Guid ticketsId)
        {
            GetTicketResult result = await _ticketsBusiness
                                           .Get(new GetTicketDto
                                           {
                                               ticketsId = ticketsId,
                                               MembersId = MembersId
                                           });

            return StatusCode(result.StatusCode, result);
        }
    }
}
