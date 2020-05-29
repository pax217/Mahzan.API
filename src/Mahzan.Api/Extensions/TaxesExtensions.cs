using Mahzan.Business.Implementations.Business.Taxes;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Dapper.Implementations.Taxes;
using Mahzan.Dapper.Interfaces.Taxes;
using Mahzan.DataAccess.Implementations;
using Mahzan.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Mahzan.Api.Extensions
{
    public static class TaxesExtensions
    {
        public static void ConfigureTaxesServices(
            IServiceCollection services,
            string connectionString)
        {

            //Dapper
            services.AddScoped<ITaxesDapper, TaxesDapper>(_ => new TaxesDapper(new SqlConnection(connectionString)));


            //Busienss
            services.AddTransient<ITaxesBusiness, TaxesBusiness>();

            services.AddTransient<ITaxesRepository, TaxesRepository>();

            

        }
    }
}
