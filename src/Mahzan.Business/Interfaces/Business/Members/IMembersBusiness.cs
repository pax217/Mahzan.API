using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Members;
using Mahzan.DataAccess.DTO.Members;

namespace Mahzan.Business.Interfaces.Business.Members
{
    public interface IMembersBusiness
    {
        Task<AddMembersResult> Add(AddMembersDto addMiembrosDto);

        Models.Entities.Members Get(string userName);

    }
}
