using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Mahzan.Dapper.Repositories.Tickets.GetTicket
{
    public class GetTicketRepository : DataConnection, IGetTicketRepository
    {
        public GetTicketRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Tickets> GetByTicketsId(Guid ticketsId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from Tickets ");
            sql.Append("Where TicketsId = @TicketsId ");


            IEnumerable<Models.Entities.Tickets> tickets;
            tickets = await Connection
                .QueryAsync<Models.Entities.Tickets>(
                sql.ToString(),
                new
                {
                    TicketsId = ticketsId
                });

            return tickets.FirstOrDefault();
        }
    }
}
