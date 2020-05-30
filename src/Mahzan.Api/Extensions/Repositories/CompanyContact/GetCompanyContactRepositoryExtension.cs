using Mahzan.Dapper.Repositories.Company_Contact.GetCompanyContact;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Repositories.CompanyContact
{
    public static class GetCompanyContactRepositoryExtension
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString)
        {
            services
                .AddScoped<IGetCompanyContactRepository>(
                x => new GetCompanyContactRepository(
                    new SqlConnection(connectionString)
                    ));
        }
    }
}
