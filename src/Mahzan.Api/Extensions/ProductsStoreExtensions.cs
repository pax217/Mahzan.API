using Mahzan.Business.Implementations.Business.ProductsStore;
using Mahzan.Business.Interfaces.Business.ProductsStore;
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
    public static class ProductsStoreExtensions
    {
        public static void ProductsStoreBlServices(this IServiceCollection services)
        {
            BusinessBlServices(services);
            RepositoriesBlServices(services);
            ValidationsBlServices(services);
        }

        private static void BusinessBlServices(this IServiceCollection services)
        {
            services.AddTransient<IProductsStoreBusiness, ProductsStoreBusiness>();
        }

        private static void RepositoriesBlServices(this IServiceCollection services)
        {
            services.AddTransient<IProductsStoreRepository, ProductsStoreRepository>();


        }

        private static void ValidationsBlServices(this IServiceCollection services)
        {

        }
    }
}
