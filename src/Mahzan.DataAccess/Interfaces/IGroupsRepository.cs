using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IGroupsRepository: IRepositoryBase<Groups>
    {
        PagedList<Groups> Get(GetGroupsDto getGroupsDto);

        Groups Update(PutGroupsDto putGroupsDto);

        Groups Delete(DeleteGroupsDto deleteGroupsDto);
    }
}
