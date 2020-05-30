using Mahzan.Dapper.Repositories.AspNetUsers.GetAspNetUsers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.AspNetUsers
{
    public static class GetAspNetUsersRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetAspNetUsersRepository>(
                x => new GetAspNetUsersRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
