using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Companies;
using Mahzan.Business.Resources.Validations.Companies;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.Companies
{
    public class PutCompaniesValidations: IPutCompaniesValidations
    {
        readonly ICompaniesRepository _companiesRepository;

        readonly IStoresRepository _storesRepository;

        public PutCompaniesValidations(
            ICompaniesRepository companiesRepository,
            IStoresRepository storesRepository)
        {
            _companiesRepository = companiesRepository;

            _storesRepository = storesRepository;
        }

        public async Task<PutCompaniesResult> PutCompaniesValid(PutCompaniesDto putCompaniesDto)
        {
            PutCompaniesResult result = new PutCompaniesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutCompaniesValidationsResources.ResourceManager.GetString("Put_Valid_Title"),
                Message = PutCompaniesValidationsResources.ResourceManager.GetString("Put_Valid_200_SUCCESS_Message")
            };

           
            PagedList<Models.Entities.Companies> Companies = await _companiesRepository
                                                                .Get(new GetCompaniesDto
                                                                {
                                                                    CompaniesId = putCompaniesDto.CompaniesId
                                                                });
            //Actualización de Grupo
            if (Companies.Any())
            {
                if (Companies.FirstOrDefault().GroupsId
                    != putCompaniesDto.GroupsId)
                {
                    PagedList<Models.Entities.Stores> Stores = _storesRepository
                                                                .Get(new GetStoresDto
                                                                {
                                                                    CompaniesId = Companies.FirstOrDefault().CompaniesId
                                                                });

                    if (Stores.Any())
                    {
                        result.IsValid = false;
                        result.StatusCode = 500;
                        result.ResultTypeEnum = ResultTypeEnum.WARNING;
                        result.Message = PutCompaniesValidationsResources.ResourceManager.GetString("Put_Valid_500_WARNING_Message_GroupsId");

                        return result;
                    }
                }
            }


            return result;
        }
    }
}
