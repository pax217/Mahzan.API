using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.TicketDetail.GetTicketDetail
{
    public class GetTicketDetailRepository : DataConnection, IGetTicketDetailRepository
    {
        public GetTicketDetailRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.TicketDetail>> GetByTicketsId(Guid TicketsId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from TicketDetail ");
            sql.Append("Where TicketsId = @TicketsId ");

            IEnumerable<Models.Entities.TicketDetail> ticketDetail;
            ticketDetail = await Connection
                .QueryAsync<Models.Entities.TicketDetail>(
                sql.ToString(),
                new
                {
                    TicketsId = TicketsId
                });

            return ticketDetail.ToList();
        }
    }
}
