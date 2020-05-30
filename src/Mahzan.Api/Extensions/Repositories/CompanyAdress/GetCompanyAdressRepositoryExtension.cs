using Mahzan.Dapper.Repositories.Company_Adress.GetCompanyAdress;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.CompanyAdress
{
    public static class GetCompanyAdressRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetCompanyAdressRepository>(
                x => new GetCompanyAdressRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
