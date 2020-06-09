using Dapper;
using Mahzan.Dapper.Exceptions.AspNetRoles.GetAspNetRoles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.AspNetRoles.GetAspNetRoles
{
    public class GetAspNetRolesRepository : DataConnection,IGetAspNetRolesRepository
    {
        public GetAspNetRolesRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.AspNetRoles>> Handle()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from AspNetRoles ");
            sql.Append("Where Name Not In ('MEMBER')");

            IEnumerable<Models.Entities.AspNetRoles> roles;
            roles = await Connection
                .QueryAsync<Models.Entities.AspNetRoles>(
                sql.ToString()
                );

            if (!roles.Any())
            {
                throw new GetAspNetRolesKeyNotFoundException(
                    $"No se encontró información de roles."
                    );
            }


            return roles.ToList();
        }
    }
}
