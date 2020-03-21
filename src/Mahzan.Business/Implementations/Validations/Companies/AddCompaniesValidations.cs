using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Companies;
using Mahzan.Business.Resources.Validations.Companies;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.Companies
{
    public class AddCompaniesValidations: IAddCompaniesValidations
    {
        private readonly ICompaniesRepository _companiesRepository;

        private readonly IGroupsRepository _groupsRepository;

        public AddCompaniesValidations(
            ICompaniesRepository companiesRepository,
            IGroupsRepository groupsRepository)
        {
            _companiesRepository = companiesRepository;
            _groupsRepository = groupsRepository;
        }

        public async Task<AddCompaniesResult> AddCompaniesValid(AddCompaniesDto addCompaniesDto)
        {
            AddCompaniesResult result = new AddCompaniesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddCompaniesValidationsResources.ResourceManager.GetString("Add_Valid_Title"),
                Message = AddCompaniesValidationsResources.ResourceManager.GetString("Add_Valid_200_SUCCESS_Message")
            };

            //Valida RFC Correcto
            if (!ValidateRFC(addCompaniesDto.RFC))
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddCompaniesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_RFC_No_Valid");

                return result;
            }

            //Valida que el RFC no exista
            if (await ValidateRFCExist(addCompaniesDto.RFC, addCompaniesDto.MembersId))
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddCompaniesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_RFC");

                return result;
            }

            //Valida que el Grupo exista
            if (!await ValidateGroupExist(addCompaniesDto.GroupsId, addCompaniesDto.MembersId))
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = string.Format(AddCompaniesValidationsResources
                                               .ResourceManager
                                               .GetString("Add_Valid_500_WARNING_Message_GroupsId"),
                                               addCompaniesDto.GroupsId);

                return result;
            }

            return result;
        }

        private bool ValidateRFC(string rfc) 
        {
            Regex regex = new Regex(@"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$");
            Match match = regex.Match(rfc);

            return match.Success;
        }

        private async Task<bool> ValidateRFCExist(string rfc,
                                                  Guid membersId) 
        {
            PagedList<Models.Entities.Companies> companies = await _companiesRepository
                                                      .Get(new GetCompaniesDto
                                                      {
                                                          RFC = rfc,
                                                          MembersId = membersId
                                                      });

            return companies.Any() ? true : false;
        }

        private async Task<bool> ValidateGroupExist(Guid groupsId,
                                                    Guid membersId) 
        {
            PagedList<Models.Entities.Groups> groups = await _groupsRepository
                                                             .Get(new GetGroupsDto
                                                             {
                                                                 GroupsId = groupsId,
                                                                 MembersId = membersId
                                                             });

            return groups.Any() ? true : false;
        }
    }
}
