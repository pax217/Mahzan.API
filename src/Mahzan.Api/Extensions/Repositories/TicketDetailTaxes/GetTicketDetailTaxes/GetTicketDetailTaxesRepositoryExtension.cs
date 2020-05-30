using Mahzan.Dapper.Repositories.TicketDetailTaxes.GetTicketDetailTaxes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.TicketDetailTaxes.GetTicketDetailTaxes
{
    public static class GetTicketDetailTaxesRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetTicketDetailTaxesRepository>(
                x => new GetTicketDetailTaxesRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
