using System;
using System.Diagnostics.CodeAnalysis;
using Mahzan.Business.Implementations.Business.Groups;
using Mahzan.Business.Implementations.Validations.Groups;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Interfaces.Validations.Groups;
using Mahzan.DataAccess.Implementations;
using Mahzan.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mahzan.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class GroupsExtensions
    {
        public static void GroupsBlServices(this IServiceCollection services)
        {

        }

        private static void RepositoriesBlServices(this IServiceCollection services)
        {
            services.AddTransient<IGroupsRepository, GroupsRepository>();

            services.AddTransient<IGroupsRepositories, GroupsRepositories>();
        }

        private static void ValidationsBlServices(this IServiceCollection services)
        {
            services.AddTransient<IAddGroupsValidations, AddGroupsValidations>();
            services.AddTransient<IDeleteGroupsValidations, DeleteGroupsValidations>();

            services.AddTransient<IGroupsValidations, GroupsValidations>();
        }
    }
}
