using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Mahzan.Business.Interfaces.Validations.Groups;

namespace Mahzan.Business.Implementations.Business.Groups
{
    public class GroupsBusiness: IGroupsBusiness
    {
        private readonly IGroupsRepositories _groupsRepositories;
        
        private readonly IGroupsValidations _groupsValidations;

        public GroupsBusiness(
            IGroupsRepositories groupsRepositories,
            IGroupsValidations groupsValidations)
        {

            _groupsValidations = groupsValidations;

            _groupsRepositories = groupsRepositories;

        }

        public async Task<AddGroupsResult> Add(AddGroupsDto addGroupsDto)
        {
            AddGroupsResult result = new AddGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddGroupsResources.ResourceManager.GetString("Add_Title"),
                Message = AddGroupsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Valida la información del grupo a agregar
                AddGroupsResult resultValidations = await _groupsValidations
                                                          .AddGroupsValid(addGroupsDto);

                if (!resultValidations.IsValid)
                {
                    return resultValidations;
                }

                //Agrega Grupo
                result.Group = await _groupsRepositories
                                     .AddGroup(addGroupsDto);


            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<GetGroupsResult> Get(GetGroupsDto getGroupsDto)
        {
            GetGroupsResult result = new GetGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetGroupsResources.ResourceManager.GetString("Get_Title"),
                Message = GetGroupsResources.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            try
            {

                result.Groups = await _groupsRepositories
                                       .GetGroups(getGroupsDto);

                if (!result.Groups.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetGroupsResources.ResourceManager.GetString("Get_200_INFO_Message");

                    return result;
                }


            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<PutGroupsResult> Put(PutGroupsDto putGroupsDto)
        {
            PutGroupsResult result = new PutGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutGroupsResources.ResourceManager.GetString("Put_Title"),
                Message = PutGroupsResources.ResourceManager.GetString("Put_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al Actualizar

                await _groupsRepositories
                      .UpdateGroup(putGroupsDto);
                
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<DeleteGroupsResult> Delete(DeleteGroupsDto deleteGroupsDto)
        {
            DeleteGroupsResult result = new DeleteGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteGroupsResources.ResourceManager.GetString("Delete_Title"),
                Message = DeleteGroupsResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")
            };

            try
            {
                //Valida información al eliminar el Grupo
                DeleteGroupsResult resultValidations = await _groupsValidations
                                                             .DeleteGroupsValid(deleteGroupsDto);

                if (!resultValidations.IsValid)
                {
                    return resultValidations;
                }

                //Agrega Grupo
                await _groupsRepositories
                      .DeleteGroup(deleteGroupsDto);

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
