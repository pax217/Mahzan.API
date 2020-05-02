using Mahzan.Business.Implementations.Business.Clients;
using Mahzan.Business.Implementations.Validations.Clients;
using Mahzan.Business.Interfaces.Business.Clients;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Dapper.Implementations.Clients;
using Mahzan.Dapper.Interfaces.Clients;
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

            //Dapper
            services.AddScoped<IClientsDapper, ClientsDapper>(_ => new ClientsDapper(new SqlConnection(connectionString)));

            //Validations
            services.AddTransient<IAddClientValidations, AddClientValidations>();

            //Busienss
            services.AddTransient<IClientsBusiness, ClientsBusiness>();
        }
    }
}
