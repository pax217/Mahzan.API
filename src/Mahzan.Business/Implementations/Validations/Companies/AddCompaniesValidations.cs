using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Companies;
using Mahzan.Business.Resources.Validations.Companies;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.Companies
{
    public class AddCompaniesValidations: IAddCompaniesValidations
    {
        readonly ICompaniesRepository _companiesRepository;

        public AddCompaniesValidations(
            ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
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
            Regex regex = new Regex(@"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$");
            Match match = regex.Match(addCompaniesDto.RFC);

            if (!match.Success)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddCompaniesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_RFC_No_Valid");

                return result;
            }

            //Valida que el RFC no exista
            PagedList<Models.Entities.Companies> companies = _companiesRepository
                                                              .Get(new GetCompaniesDto
                                                              {
                                                                  GroupsId = addCompaniesDto.GroupsId,
                                                                  RFC = addCompaniesDto.RFC
                                                              });

            if (companies.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddCompaniesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_RFC");

                return result;
            }

            return result;
        }
    }
}
