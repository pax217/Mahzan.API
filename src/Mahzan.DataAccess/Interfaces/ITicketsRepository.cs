using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketsRepository
    {
        Task<Tickets> Add(TicketCalculationDto addTicketsDto);
    }
}
