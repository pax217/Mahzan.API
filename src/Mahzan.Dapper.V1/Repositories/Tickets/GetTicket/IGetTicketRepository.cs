using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Tickets.GetTicket
{
    public interface IGetTicketRepository
    {
        Task<Models.Entities.Tickets> GetByTicketsId(Guid ticketsId);
    }
}
