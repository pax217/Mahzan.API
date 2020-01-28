using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Groups;
using Mahzan.Business.Resources.Business.Groups;
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
        readonly ICompaniesRepository _companiesRepository;

        public DeleteGroupsValidations(
            ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<DeleteGroupsResult> DeleteGroupsValid(DeleteGroupsDto deleteGroupsDto)
        {
            DeleteGroupsResult result = new DeleteGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteGroupsResources.ResourceManager.GetString("Delete_Valid_Title"),
                Message = DeleteGroupsResources.ResourceManager.GetString("Delete_Valid_200_SUCCESS_Message")
            };

            //Valida que no tenga companias asociadas
            PagedList<Models.Entities.Companies> companies = _companiesRepository
                                                              .Get(new GetCompaniesDto {
                                                                  MembersId = deleteGroupsDto.MembersId,
                                                                  GroupsId = deleteGroupsDto.GroupsId
                                                              });
            if (companies.Any())
            {
                result.IsValid = false;
                result.StatusCode = 400;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = DeleteGroupsResources.ResourceManager.GetString("Delete_Valid_400_WARNING_Message_Companies");

                return result;
            }

            return result;
        }
    }
}
