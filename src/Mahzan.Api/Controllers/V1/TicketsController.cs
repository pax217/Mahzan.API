using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Events.Tickets.GetTicketToPrint;
using Mahzan.Business.EventsHandlers.Tickets.GetTicketToPrint;
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
        private readonly IGetTicketToPrintEventHandler _getTicketToPrintEventHandler;

        readonly ITicketsBusiness _ticketsBusiness;

        public TicketsController(
            IMembersBusiness miembrosBusiness,
            ITicketsBusiness ticketsBusiness, 
            IGetTicketToPrintEventHandler getTicketToPrintEventHandler)
            : base(miembrosBusiness)
        {

            _ticketsBusiness = ticketsBusiness;
            _getTicketToPrintEventHandler = getTicketToPrintEventHandler;
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
                                                  ClientsId = postTicketCalculationRequest.ClientsId,
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
                                               TicketsId = getTicketsFilter.TicketsId,
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

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}/get-ticket-to-print")]
        public async Task<IActionResult> GetTicketToPrint(Guid id) 
        {
            GetTicketToPrintResult result = new GetTicketToPrintResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Ticket = "Obtiene ticket a imprimir",
                Message =$"Se obtuvo de forma correcta el ticket {id}."
            };

            try
            {
                result.Ticket=  await _getTicketToPrintEventHandler
                    .Handle(new GetTicketToPrintEvent
                    {
                        TicketsId = id,
                        MembersId = MembersId
                    });
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok(result);
        }

    }
}
