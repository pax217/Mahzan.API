using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Business.Interfaces.Validations.Taxes;
using Mahzan.Business.Resources.Business.Companies;
using Mahzan.Business.Resources.Business.Taxes;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.DTO.Taxes;
using Mahzan.DataAccess.DTO.TaxesStores;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Taxes
{
    public class TaxesBusiness: ITaxesBusiness
    {
        //Repository
        readonly ITaxesRepository _taxesRepository;
        readonly ITaxesStoresRepository _taxesStoresRepository;

        readonly IAddTaxesValidations _addTaxesValidations;

        public TaxesBusiness(
            ITaxesRepository taxesRepository,
            ITaxesStoresRepository taxesStoresRepository,
            IAddTaxesValidations addTaxesValidations)
        {
            //Repositories
            _taxesRepository = taxesRepository;
            _taxesStoresRepository = taxesStoresRepository;

            //Validations
            _addTaxesValidations = addTaxesValidations;
        }

        public async Task<PostTaxesResult> Add(AddTaxesDto addTaxesDto)
        {
            PostTaxesResult result = new PostTaxesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddTaxesResources.ResourceManager.GetString("Add_Title"),
                Message = AddTaxesResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones de Impuestos
                PostTaxesResult resultValidations = await _addTaxesValidations
                                                           .AddTaxesValid(addTaxesDto);

                if (!resultValidations.IsValid)
                {
                    return resultValidations;
                }

                //Agrega Impuesto
                Models.Entities.Taxes newTax = _taxesRepository.Add(addTaxesDto);


                //Agrega Impuesto a Tienda
                result.Taxes_Stores = _taxesStoresRepository.Add(new AddTaxesStoresDto {
                    MembersId = addTaxesDto.MembersId,
                    TaxesId = newTax.TaxesId,
                    StoresIds = addTaxesDto.StoresIds
                });

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
