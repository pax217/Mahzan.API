using Mahzan.Dapper.Repositories.Tickets.GetTicketToPrint;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Tickets
{
    public static class GetTicketToPrintRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetTicketToPrintRepository>(
                x => new GetTicketToPrintRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
