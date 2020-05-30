using Mahzan.Dapper.Repositories.PointsOfSales.GetPointsOfSale;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.PointsOfSales
{
    public static class GetPointsOfSaleRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetPointsOfSaleRepository>(
                x => new GetPointsOfSaleRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
