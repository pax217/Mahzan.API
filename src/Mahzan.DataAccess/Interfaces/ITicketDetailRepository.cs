using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketDetailRepository: IRepositoryBase<TicketDetail>
    {
        Task<TicketDetail> Add(Tickets newTicket,
                               AddTicketsDto addTicketsDto);
    }
}
