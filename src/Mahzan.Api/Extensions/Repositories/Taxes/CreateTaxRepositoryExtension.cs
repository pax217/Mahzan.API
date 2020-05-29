using Mahzan.Dapper.Repositories.Taxes.CreateTax;
using Mahzan.Dapper.Rules.Taxes.CreateTax;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Taxes
{
    public static class CreateTaxRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateTaxRepository>(
                x => new CreateTaxRepository(
                    new SqlConnection(connectionString),
                    x.GetService<ICreateTaxRules>()
                    ));
        }
    }
}
