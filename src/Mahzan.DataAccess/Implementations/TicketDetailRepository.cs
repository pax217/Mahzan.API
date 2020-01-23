using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class TicketDetailRepository: RepositoryBase<TicketDetail>, ITicketDetailRepository
    {
        public TicketDetailRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Task<TicketDetail> Add(Tickets newTicket, AddTicketsDto addTicketsDto)
        {
            throw new NotImplementedException();
        }
    }
}
