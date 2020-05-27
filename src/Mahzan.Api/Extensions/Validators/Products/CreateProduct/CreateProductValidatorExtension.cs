using Mahzan.Business.Validators.Products.CreateProduct;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.Validators.Products.CreateProduct
{
    public static class CreateProductValidatorExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddTransient<ICreateProductValidator, CreateProductValidator>();
        }

    }
}
