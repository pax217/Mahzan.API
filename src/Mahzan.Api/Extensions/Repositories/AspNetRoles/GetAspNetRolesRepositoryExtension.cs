using Mahzan.Dapper.Repositories.AspNetRoles.GetAspNetRoles;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.AspNetRoles
{
    public static class GetAspNetRolesRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetAspNetRolesRepository>(
                x => new GetAspNetRolesRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }


}
