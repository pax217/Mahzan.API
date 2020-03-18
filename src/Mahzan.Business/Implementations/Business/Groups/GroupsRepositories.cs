using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Business.Groups
{
    public class GroupsRepositories : IGroupsRepositories
    {
        readonly IGroupsRepository _groupsRepository;

        public GroupsRepositories(
            IGroupsRepository groupsRepository
            )
        {
            _groupsRepository = groupsRepository;
        }

        /// <summary>
        /// Agrega Grupo
        /// </summary>
        /// <param name="addGroupsDto"></param>
        /// <returns></returns>
        public async Task<Models.Entities.Groups> AddGroup(AddGroupsDto addGroupsDto)
        {
            return await _groupsRepository
                         .Add(addGroupsDto);
        }

        /// <summary>
        /// Elimina Grupo
        /// </summary>
        /// <param name="deleteGroupsDto"></param>
        /// <returns></returns>
        public async Task<Models.Entities.Groups> DeleteGroup(DeleteGroupsDto deleteGroupsDto)
        {
            return await _groupsRepository
                         .Delete(deleteGroupsDto);
        }

        /// <summary>
        /// Obtiene Grupos
        /// </summary>
        /// <param name="getGroupsDto"></param>
        /// <returns></returns>
        public async Task<PagedList<Models.Entities.Groups>> GetGroups(GetGroupsDto getGroupsDto)
        {
            return await _groupsRepository
                         .Get(getGroupsDto);
        }

        /// <summary>
        /// Actualiza Grupo
        /// </summary>
        /// <returns></returns>
        public async Task<Models.Entities.Groups> UpdateGroup(PutGroupsDto putGroupsDto)
        {
            return await _groupsRepository
                          .Update(putGroupsDto);
        }

    }
}
