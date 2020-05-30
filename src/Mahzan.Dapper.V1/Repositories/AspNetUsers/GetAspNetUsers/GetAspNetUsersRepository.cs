using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.AspNetUsers.GetAspNetUsers
{
    public class GetAspNetUsersRepository : DataConnection, IGetAspNetUsersRepository
    {
        public GetAspNetUsersRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.AspNetUsers> GetById(Guid id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select * from AspNetUsers ");
            sql.Append("where Id = @Id ");

            IEnumerable<Models.Entities.AspNetUsers> aspNetUsers;
            aspNetUsers = await Connection
                .QueryAsync<Models.Entities.AspNetUsers>(
                sql.ToString(),
                new
                {
                    Id = id
                });

            return aspNetUsers.FirstOrDefault();
        }
    }
}
