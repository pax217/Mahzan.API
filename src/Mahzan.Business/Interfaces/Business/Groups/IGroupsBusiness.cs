using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;

namespace Mahzan.Business.Interfaces.Business.Groups
{
    public interface IGroupsBusiness
    {
        Task<AddGroupsResult> Add(AddGroupsDto addGroupsDto);
    }
}
