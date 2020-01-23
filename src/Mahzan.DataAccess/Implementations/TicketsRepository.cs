using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class TicketsRepository: RepositoryBase<Tickets>, ITicketsRepository
    {
        readonly IMapper _mapper;

        public TicketsRepository(
            MahzanDbContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {

            _mapper = mapper;
        }

        public async Task<Tickets> Add(AddTicketsDto addTicketsDto)
        {
            Tickets newTicket = null;

            newTicket = _mapper.Map<Tickets>(addTicketsDto);

            newTicket.CreatedAt = DateTime.Now;

            _context.Set<Tickets>().Add(newTicket);

            await _context.SaveChangesAsync();

            return newTicket;

        }
    }
}
