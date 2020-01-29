using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Taxes;
using Mahzan.Business.Resources.Validations.Taxes;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.DTO.Taxes;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.Taxes
{
    public class AddTaxesValidations: IAddTaxesValidations
    {
        readonly ITaxesRepository _taxesRepository;

        public AddTaxesValidations(
            ITaxesRepository taxesRepository)
        {
            _taxesRepository = taxesRepository;
        }

        public async Task<PostTaxesResult> AddTaxesValid(AddTaxesDto addTaxesDto)
        {
            PostTaxesResult result = new PostTaxesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddTaxesValidationsResources.ResourceManager.GetString("Add_Valid_Title"),
                Message = AddTaxesValidationsResources.ResourceManager.GetString("Add_Valid_200_SUCCESS_Message")
            };

            //Valida que el Nombre del Impuesto no exista
            PagedList<Models.Entities.Taxes> taxesName =  _taxesRepository
                                                          .Get(new GetTaxesDto
                                                            {
                                                                MembersId= addTaxesDto.MembersId,
                                                                Name = addTaxesDto.Name
                                                            }
                                                          );

            if (taxesName.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddTaxesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_Name");

                return result;
            }

            return result;
        }
    }
}
