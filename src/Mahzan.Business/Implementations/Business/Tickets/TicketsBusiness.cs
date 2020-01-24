using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Resources.Business.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Tickets
{
    public class TicketsBusiness: ITicketsBusiness
    {
        readonly ITicketDetailRepository _ticketDetailRepository;

        readonly ITicketsRepository _ticketsRepository;

        public TicketsBusiness(
            ITicketDetailRepository ticketDetailRepository,
            ITicketsRepository ticketsRepository)
        {
            _ticketDetailRepository = ticketDetailRepository;
            _ticketsRepository = ticketsRepository;
        }

        public async Task<PostTicketsResult> Add(AddTicketsDto addTicketsDto)
        {
            PostTicketsResult result = new PostTicketsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddTicketsResources.ResourceManager.GetString("Add_Title"),
                Message = AddTicketsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            Models.Entities.Tickets newTicket = new Models.Entities.Tickets();

            try
            {
                //Validaciones de Ticket


                //Calcula Monto Total
                addTicketsDto.Total = CalculateTotal(addTicketsDto.PostTicketDetailDto);

                //Agrega ticket
                Models.Entities.Tickets addedTicket = await _ticketsRepository
                                                             .Add(addTicketsDto);

                //Agrega detalle de Ticket
                await _ticketDetailRepository
                       .Add(addedTicket,
                            addTicketsDto.PostTicketDetailDto);
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

        #region Private Methods

        public decimal CalculateTotal(List<PostTicketDetailDto> postTicketDetailDtos)
        {
            decimal result = 0;

            foreach (var ticketDetail in postTicketDetailDtos)
            {
                //Obtener productos y calcular el total.
                result += ticketDetail.Amount;
            }

            return result;
        }


        #endregion
    }
}
