using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Groups;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Resources.Validations.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.Business.Implementations.Validations.Groups
{
    public class DeleteGroupsValidations: IDeleteGroupsValidations
    {
        private readonly IGroupsRepository _groupsRepository;

        private readonly ICompaniesRepository _companiesRepository;

        public DeleteGroupsValidations(
            IGroupsRepository groupsRepository,
            ICompaniesRepository companiesRepository)
        {
            _groupsRepository = groupsRepository;

            _companiesRepository = companiesRepository;
        }

        public async Task<DeleteGroupsResult> DeleteGroupsValid(DeleteGroupsDto deleteGroupsDto)
        {
            DeleteGroupsResult result = new DeleteGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteGroupsValidationsResources.ResourceManager.GetString("Delete_Valid_Title"),
                Message = DeleteGroupsValidationsResources.ResourceManager.GetString("Delete_Valid_200_SUCCESS_Message")
            };


            //Valida que el Grupo exista
            if (!await ValidateGroupExist(deleteGroupsDto.GroupsId,
                                          deleteGroupsDto.MembersId))
            {
                result.IsValid = false;
                result.StatusCode = 400;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = string.Format(DeleteGroupsValidationsResources
                                               .ResourceManager
                                               .GetString("Delete_Valid_400_WARNING_Message_Group_No_Exist"),
                                               deleteGroupsDto.GroupsId);

                return result;
            }


            ////Valida que no tenga companias asociadas
            //PagedList<Models.Entities.Companies> companies = _companiesRepository
            //                                                  .Get(new GetCompaniesDto {
            //                                                      MembersId = deleteGroupsDto.MembersId,
            //                                                      GroupsId = deleteGroupsDto.GroupsId
            //                                                  });
            //if (companies.Any())
            //{
            //    result.IsValid = false;
            //    result.StatusCode = 400;
            //    result.ResultTypeEnum = ResultTypeEnum.WARNING;
            //    result.Message = DeleteGroupsResources.ResourceManager.GetString("Delete_Valid_400_WARNING_Message_Companies");

            //    return result;
            //}

            return result;
        }

        #region Private Methods

        private async Task<bool> ValidateGroupExist(Guid groupsId,
                                                    Guid membersId)
        {

            PagedList<Models.Entities.Groups> groups = await _groupsRepository  
                                                              .Get(new GetGroupsDto
                                                              {
                                                                  GroupsId = groupsId,
                                                                  MembersId = membersId,
                                                                  Active = true
                                                              });

            return groups.Any() ? true :  false;
        }



        #endregion
    }
}
