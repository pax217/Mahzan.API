using Mahzan.Dapper.DTO.Tickets.GetTicketToPrint;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Tickets.GetTicketToPrint
{
    public interface IGetTicketToPrintRepository
    {
        Task<Models.Entities.Tickets> Handle(GetTicketToPrintDto getTicketToPrintDto);
    }
}
