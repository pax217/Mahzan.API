using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Interfaces.TicketsRepositoryServices
{
    public interface IAddTicketRepositoryService
    {
        Task<Tickets> Add(TicketCalculationDto addTicketsDto);
    }
}
