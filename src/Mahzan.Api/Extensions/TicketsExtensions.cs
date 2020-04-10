using Mahzan.Business.Implementations.Business.Tickets;
using Mahzan.Business.Implementations.Validations.Tickets;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Interfaces.Validations.Tickets;
using Mahzan.DataAccess.Implementations;
using Mahzan.DataAccess.Implementations.TicketsRepositoryServices;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Interfaces.TicketsRepositoryServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class TicketsExtensions
    {
        public static void TicketsBlServices(this IServiceCollection services)
        {
            RepositoriesBlServices(services);
            ValidationsBlServices(services);
            BusinessBlServices(services);
        }

        private static void BusinessBlServices(this IServiceCollection services)
        {
            services.AddTransient<ITicketsBusiness, TicketsBusiness>();
        }

        private static void RepositoriesBlServices(this IServiceCollection services)
        {
            services.AddTransient<ITicketsRepository, TicketsRepository>();

            services.AddTransient<ITicketsRepositories, TicketsRepositories>();

            services.AddTransient<IAddTicketRepositoryService, AddTicketRepositoryService>();
            
        }

        private static void ValidationsBlServices(this IServiceCollection services)
        {
            services.AddTransient<IAddTicketsValidations, AddTicketsValidations>();
            services.AddTransient<ITicketsValidations, TicketsValidations>();
            
        }
    }
}
