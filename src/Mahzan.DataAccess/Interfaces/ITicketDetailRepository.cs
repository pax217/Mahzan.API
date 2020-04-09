using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketDetailRepository: IRepositoryBase<TicketDetail>
    {
        Task<TicketDetail> Add(Tickets newTicket);

        Task<List<TicketDetail>> Add(Tickets newTicket,
                                     List<PostTicketCalculationDetailDto> postTicketDetailDto);
    }
}
