using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Groups;
using Mahzan.Business.Resources.Validations.Gruops;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Validations.Groups
{
    public class AddGroupsValidations: IAddGroupsValidations
    {
        readonly IGroupsRepository _groupsRepository;

        public AddGroupsValidations(
            IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public async Task<AddGroupsResult> AddGroupsValid(AddGroupsDto addGroupsDto)
        {
            AddGroupsResult result = new AddGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddGroupsValidationsResources.ResourceManager.GetString("AddMembersValid_Title"),
                Message = AddGroupsValidationsResources.ResourceManager.GetString("AddMembersValid_200_SUCCESS_Message")
            };

            //Valida que el nombre del Grupo no exista para este miembro
            List<Models.Entities.Groups> groupExist = _groupsRepository
                                                       .Get(new GetGroupsDto
                                                       {
                                                           MembersId = addGroupsDto.MembersId,
                                                           Name = addGroupsDto.Name
                                                       });
            if (groupExist.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddGroupsValidationsResources.ResourceManager.GetString("AddMembersValid_500_WARNING_Message");

                return result;
            }

            return result;
        }
    }
}
