using Mahzan.Dapper.Repositories.Stores.GetStore;
using Mahzan.Dapper.Repositories.Taxes.GetTax;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.Stores.GetStore
{
    public static class GetStoreRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetStoreRepository>(
                x => new GetStoreRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
