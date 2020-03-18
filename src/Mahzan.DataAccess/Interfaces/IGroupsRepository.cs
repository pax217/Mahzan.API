using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IGroupsRepository: IRepositoryBase<Groups>
    {
        Task<Groups> Add(AddGroupsDto addGroupsDto);

        Task<PagedList<Groups>> Get(GetGroupsDto getGroupsDto);

        Task<Groups> Update(PutGroupsDto putGroupsDto);

        Task<Groups> Delete(DeleteGroupsDto deleteGroupsDto);
    }
}
