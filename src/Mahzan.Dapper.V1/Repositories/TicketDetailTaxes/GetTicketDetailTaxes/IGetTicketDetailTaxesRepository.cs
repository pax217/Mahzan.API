using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.TicketDetailTaxes.GetTicketDetailTaxes
{
    public interface IGetTicketDetailTaxesRepository
    {
        Task<List<Models.Entities.TicketDetailTaxes>> GetByTicketsId(Guid ticketsId); 
    }
}
