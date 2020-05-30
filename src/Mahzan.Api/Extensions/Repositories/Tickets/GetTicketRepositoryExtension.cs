using Mahzan.Dapper.Repositories.Tickets.GetTicket;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Tickets
{
    public static class GetTicketRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetTicketRepository>(
                x => new GetTicketRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
