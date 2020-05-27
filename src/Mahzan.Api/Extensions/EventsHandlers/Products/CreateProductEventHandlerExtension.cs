using Mahzan.Business.EventsHandlers.Products.CreateProduct;
using Mahzan.Business.Validators.Products.CreateProduct;
using Mahzan.Dapper.Repositories.Products.CreateProduct;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Products
{
    public static class CreateProductEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<ICreateProductEventHandler>(
                x => new CreateProductEventHandler(
                    x.GetService<ICreateProductRepository>(),
                    x.GetService<ICreateProductValidator>()
                    )
                );
        }
        
    }
}
