using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Members;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IMembersRepository : IRepositoryBase<Members>
    {
        Task<Members> Add(AddMembersDto addMembersDto);
    }
}
