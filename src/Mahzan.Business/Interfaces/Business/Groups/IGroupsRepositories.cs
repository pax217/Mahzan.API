using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Interfaces.Business.Groups
{
    public interface IGroupsRepositories
    {
        Task<Models.Entities.Groups> AddGroup(AddGroupsDto addGroupsDto);

        Task<PagedList<Models.Entities.Groups>> GetGroups(GetGroupsDto getGroupsDto);

        Task<Models.Entities.Groups> UpdateGroup(PutGroupsDto putGroupsDto);

        Task<Models.Entities.Groups> DeleteGroup(DeleteGroupsDto deleteGroupsDto);
    }
}
