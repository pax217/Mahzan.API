using Mahzan.Dapper.Rules.Taxes.CreateTax;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Taxes.CreateTax
{
    public static class CreateTaxRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateTaxRules>(
                x => new CreateTaxRules(new SqlConnection(connectionString)));
        }
    }
}
