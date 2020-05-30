using Mahzan.Dapper.Repositories.TicketDetail.GetTicketDetail;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.TicketDetail.GetTicketDetail
{
    public static class GetTicketDetailRepositoryExtension
    {

        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetTicketDetailRepository>(
                x => new GetTicketDetailRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
