using Mahzan.Dapper.Rules.Products.CreateProduct;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Rules.Products.CreateProduct
{
    public static class CreateProductRulesExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateProductRules>(
                x => new CreateProductRules(new SqlConnection(connectionString)));
        }
    }
}
