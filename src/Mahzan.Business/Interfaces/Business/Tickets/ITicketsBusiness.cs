using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;

namespace Mahzan.Business.Interfaces.Business.Tickets
{
    public interface ITicketsBusiness
    {
        Task<PostTicketCalculationResult> Calculate(TicketCalculationDto ticketCalculationDto);

        Task<PostTicketCloseSaleResult> CloseSale(TicketCalculationDto ticketCalculationDto);
    }
}
