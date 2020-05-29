using Mahzan.Business.EventsHandlers.Taxes.CreateTax;
using Mahzan.Dapper.Repositories.Taxes.CreateTax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Taxes
{
    public static class CreateTaxEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateTaxEventHandler>(
                x => new CreateTaxEventHandler(
                    x.GetService<ICreateTaxRepository>()
                    )
                );
        }
    }
}
