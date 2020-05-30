using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.TicketDetailTaxes.GetTicketDetailTaxes
{
    public class GetTicketDetailTaxesRepository : DataConnection, IGetTicketDetailTaxesRepository
    {
        public GetTicketDetailTaxesRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.TicketDetailTaxes>> GetByTicketsId(Guid ticketsId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select * from TicketDetailTaxes ");
            sql.Append("where TicketsId = @TicketsId ");

            IEnumerable <Models.Entities.TicketDetailTaxes> ticketDetailTaxes;
            ticketDetailTaxes = await Connection
                .QueryAsync<Models.Entities.TicketDetailTaxes>(
                sql.ToString(),
                new {
                    TicketsId = ticketsId
                });

            return ticketDetailTaxes.ToList();
        }
    }
}
