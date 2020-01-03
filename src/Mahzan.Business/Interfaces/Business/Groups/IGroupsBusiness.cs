using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Filters.Groups;

namespace Mahzan.Business.Interfaces.Business.Groups
{
    public interface IGroupsBusiness
    {
        Task<AddGroupsResult> Add(AddGroupsDto addGroupsDto);

        Task<GetGroupsResult> Get(GetGroupFilter getGroupFilter);

        Task<PutGroupsResult> Put(PutGroupsDto putGroupsDto);

        Task<DeleteGroupsResult> Delete(DeleteGroupsDto deleteGroupsDto);
    }
}
