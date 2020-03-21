using Mahzan.Business.Implementations.Business.Companies;
using Mahzan.Business.Implementations.Validations.Companies;
using Mahzan.Business.Implementations.Validations.Groups;
using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.Business.Interfaces.Validations.Companies;
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
    public static class CompaniesExtensions
    {
        public static void CompaniesBlServices(this IServiceCollection services)
        {
            BusinessBlServices(services);
            RepositoriesBlServices(services);
            ValidationsBlServices(services);
        }

        private static void BusinessBlServices(this IServiceCollection services)
        {
            services.AddTransient<ICompaniesBusiness, CompaniesBusiness>();
        }

        private static void RepositoriesBlServices(this IServiceCollection services)
        {
            services.AddTransient<ICompaniesRepository, CompaniesRepository>();

            services.AddTransient<ICompaniesRepositories, CompaniesRepositories>();
        }

        private static void ValidationsBlServices(this IServiceCollection services)
        {
            services.AddTransient<IAddCompaniesValidations, AddCompaniesValidations>();
            services.AddTransient<IPutCompaniesValidations, PutCompaniesValidations>();

            services.AddTransient<ICompaniesValidations, CompaniesValidations>();
        }
    }


}
