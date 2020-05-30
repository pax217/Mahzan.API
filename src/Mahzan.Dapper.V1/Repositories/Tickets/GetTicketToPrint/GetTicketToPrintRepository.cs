using Dapper;
using Mahzan.Dapper.DTO.Tickets.GetTicketToPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Tickets.GetTicketToPrint
{
    public class GetTicketToPrintRepository : DataConnection, IGetTicketToPrintRepository
    {
        public GetTicketToPrintRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Tickets> Handle(GetTicketToPrintDto getTicketToPrintDto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from Tickets ");
            sql.Append("Where TicketsId = @TicketsId ");
            sql.Append("And MembersId = @MembersId ");

            IEnumerable<Models.Entities.Tickets> tickets;
            tickets = await Connection
                .QueryAsync<Models.Entities.Tickets>(
                sql.ToString(),
                new {
                    TicketsId = getTicketToPrintDto.TicketsId,
                    MembersId = getTicketToPrintDto.MembersId
                });

            return tickets.FirstOrDefault();
        }
    }
}
