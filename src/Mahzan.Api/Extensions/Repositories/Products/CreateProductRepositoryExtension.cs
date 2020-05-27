using Mahzan.Dapper.Repositories.Products.CreateProduct;
using Mahzan.Dapper.Rules.Products.CreateProduct;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Mahzan.Api.Extensions.Repositories.Products
{
    public static class CreateProductRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<ICreateProductRepository>(
                x => new CreateProductRepository(
                    new SqlConnection(connectionString),
                    x.GetService<ICreateProductRules>()
                    ));
        }
    }
}
