using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.AspNetRoles.GetAspNetRoles
{
    public interface IGetAspNetRolesRepository
    {
        Task<List<Models.Entities.AspNetRoles>> Handle();
    }
}
