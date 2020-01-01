using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Members;
using Mahzan.DataAccess.DTO.Miembros;

namespace Mahzan.Business.Interfaces.Business.Members
{
    public interface IMembersBusiness
    {
        Task<AddMembersResult> Add(AddMiembrosDto addMiembrosDto);
        Guid Get(string userName);
    }
}
