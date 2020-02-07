using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Stores;
using Mahzan.Business.Resources.Validations.Gruops;
using Mahzan.Business.Resources.Validations.Stores;
using Mahzan.Business.Results.Stores;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.Stores
{
    public class AddStoresValidations: IAddStoresValidations
    {
        readonly IStoresRepository _storesRepository;

        public AddStoresValidations(
            IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }

        public async Task<AddStoresResult> AddStoresValid(AddStoresDto addStoresDto)
        {
            AddStoresResult result = new AddStoresResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddStoresValidationsResources.ResourceManager.GetString("Add_Valid_Title"),
                Message = AddStoresValidationsResources.ResourceManager.GetString("Add_Valid_200_SUCCESS_Message")
            };

            //Valida que el nombre no exista
            PagedList<Models.Entities.Stores> storesName = _storesRepository
                                                       .Get(new GetStoresDto
                                                       {
                                                           Name = addStoresDto.Name
                                                       });

            if (storesName.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddStoresValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_Name_No_Valid");

                return result;
            }

            //Code
            if (addStoresDto.Code!=null && addStoresDto.Code !="")
            {
                //Valida que si la tienda tiene código no exista
                PagedList<Models.Entities.Stores> storesCode = _storesRepository
                                               .Get(new GetStoresDto
                                               {
                                                   Code = addStoresDto.Code
                                               });

                if (storesCode.Any())
                {
                    result.IsValid = false;
                    result.StatusCode = 500;
                    result.ResultTypeEnum = ResultTypeEnum.WARNING;
                    result.Message = AddStoresValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_Code_No_Valid");

                    return result;
                }
            }


            return result;
        }
    }
}
