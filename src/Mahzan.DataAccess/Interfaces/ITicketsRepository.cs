using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketsRepository
    {
        Task<Tickets> Add(TicketCalculationDto addTicketsDto);

        Task<PagedList<Tickets>> GetAll(GetTicketsDto getTicketsDto);

        Task<Tickets> Get(GetTicketDto getTicketDto);
    }
}
