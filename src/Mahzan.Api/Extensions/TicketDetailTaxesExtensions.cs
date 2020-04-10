using Mahzan.DataAccess.Implementations;
using Mahzan.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class TicketDetailTaxesExtensions
    {
        public static void TicketDetailTaxesBlServices(this IServiceCollection services)
        {
            RepositoriesBlServices(services);
            ValidationsBlServices(services);
            BusinessBlServices(services);
        }

        private static void BusinessBlServices(this IServiceCollection services)
        {

        }

        private static void RepositoriesBlServices(this IServiceCollection services)
        {
            services.AddTransient<ITicketDetailRepository, TicketDetailRepository>();
            services.AddTransient<ITicketDetailTaxesRepository, TicketDetailTaxesRepository>();


        }

        private static void ValidationsBlServices(this IServiceCollection services)
        {

        }
    }
}
