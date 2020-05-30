using Mahzan.Dapper.Repositories.Companies.GetCompany;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Tickets
{
    public static class GetCompanyRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetCompanyRepository>(
                x => new GetCompanyRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
