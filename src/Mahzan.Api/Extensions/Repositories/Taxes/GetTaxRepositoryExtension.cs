using Mahzan.Dapper.Repositories.Taxes.GetTax;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Taxes
{
    public static class GetTaxRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetTaxRepository>(
                x => new GetTaxRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
