using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketDetailRepository: IRepositoryBase<TicketDetail>
    {
        Task<List<TicketDetail>> Add(Tickets newTicket,
                                     List<PostTicketDetailDto> postTicketDetailDto);
    }
}
