using Mahzan.Dapper.V1.Implementations.Clients;
using Mahzan.Dapper.V1.Interfaces.Clients;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions
{
    public static class ClientsExtensions
    {
        public static void ConfigureClientsServices(
            IServiceCollection services,
            string connectionString)
        {
            services.AddScoped<IClientsDapper, ClientsDapper>(_ => new ClientsDapper(new SqlConnection(connectionString)));
        }
    }
}
