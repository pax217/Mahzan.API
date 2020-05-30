using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.TicketDetail.GetTicketDetail
{
    public interface IGetTicketDetailRepository
    {
        Task<List<Models.Entities.TicketDetail>> GetByTicketsId(Guid TicketsId);
    }
}
