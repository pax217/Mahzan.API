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

            try
            {
                //Validaciones de Ticket


                //Agrega Ticket
                Models.Entities.Tickets newTicket = await _ticketsRepository
                                                           .Add(addTicketsDto);

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
            }

            return result;
        }


        #endregion
    }
}
