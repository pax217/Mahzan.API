using System;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Interfaces.Validations.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;

namespace Mahzan.Business.Implementations.Business.Groups
{
    public class GroupsValidations: IGroupsValidations
    {
        private readonly IAddGroupsValidations _addGroupsValidations;
        private readonly IDeleteGroupsValidations _deleteGroupsValidations;

        public GroupsValidations(
            IAddGroupsValidations addGroupsValidations,
            IDeleteGroupsValidations deleteGroupsValidations
            )
        {
            _addGroupsValidations = addGroupsValidations;
            _deleteGroupsValidations = deleteGroupsValidations;
        }

        /// <summary>
        /// Valida Grupo a agregar
        /// </summary>
        /// <param name="addGroupsDto"></param>
        /// <returns></returns>
        public async Task<AddGroupsResult> AddGroupsValid(AddGroupsDto addGroupsDto)
        {
            return await _addGroupsValidations
                         .AddGroupsValid(addGroupsDto);
        }

        public async Task<DeleteGroupsResult> DeleteGroupsValid(DeleteGroupsDto deleteGroupsDto)
        {
            return await _deleteGroupsValidations
                         .DeleteGroupsValid(deleteGroupsDto);
        }


    }
}
