using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Miembros;
using Mahzan.Business.Resources.Validations.Members;
using Mahzan.Business.Results.Members;
using Mahzan.DataAccess.DTO.Miembros;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Validations.Members
{
    public class AddMembersValidations : IAddMembersValidations
    {
        readonly IMembersRepository _membersRepository;

        public AddMembersValidations(IMembersRepository membersRepository) 
        {
            _membersRepository = membersRepository;
        }

        public async Task<AddMembersResult> AddMembersValid(AddMiembrosDto addMiembrosDto)
        {
            AddMembersResult result = new AddMembersResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title =AddMembersValidationsResource.ResourceManager.GetString("AddMembersValid_Title"),
                Message = AddMembersValidationsResource.ResourceManager.GetString("AddMembersValid_200_SUCCESS_Message")
            };

            //Identifica si el usuario ya tiene un miembro asignado
            if (_membersRepository.Get(x => x.AspNetUsersId == addMiembrosDto.AspNetUsersId).Count > 0)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddMembersValidationsResource.ResourceManager.GetString("AddMembersValid_500_WARNING_Message");

                return result;
            }


            return result;
        }
    }
}
