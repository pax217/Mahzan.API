using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.AspNetUsers.GetAspNetUsers
{
    public interface IGetAspNetUsersRepository
    {
        Task<Models.Entities.AspNetUsers> GetById(Guid id);
    }
}
