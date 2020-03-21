using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.Business.Interfaces.Validations.Companies;
using Mahzan.Business.Resources.Business.Companies;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models.Entities;

namespace Mahzan.Business.Implementations.Business.Companies
{
    public class CompaniesBusiness: ICompaniesBusiness
    {
        #region Properties

        private readonly ICompaniesValidations _companiesValidations;

        private readonly ICompaniesRepositories _companiesRepositories;

        #endregion



        public CompaniesBusiness(
            ICompaniesRepositories companiesRepositories,
            ICompaniesValidations companiesValidations)
        {
            _companiesRepositories = companiesRepositories;

            _companiesValidations = companiesValidations;
        }

        public async Task<AddCompaniesResult> Add(AddCompaniesDto addCompaniesDto)
        {
            AddCompaniesResult result = new AddCompaniesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddCompaniesResources.ResourceManager.GetString("Add_Title"),
                Message = AddCompaniesResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al agregar Company

                AddCompaniesResult resultValidations = await _companiesValidations
                                                              .AddCompaniesValid(addCompaniesDto);
                if (!resultValidations.IsValid)
                {
                    return resultValidations;
                }

                //Agrega Company a la base datos

                result.Company= await _companiesRepositories
                                      .AddCompany(addCompaniesDto);

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

        public async Task<DeleteCompaniesResult> Delete(DeleteCompaniesDto deleteCompaniesDto)
        {
            DeleteCompaniesResult result = new DeleteCompaniesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteCompaniesResources.ResourceManager.GetString("Delete_Title"),
                Message = DeleteCompaniesResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al eliminar la Company

               await _companiesRepositories
                     .DeleteCompany(deleteCompaniesDto);
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

        public async Task<GetCompaniesResult> Get(GetCompaniesDto getCompaniesDto)
        {
            GetCompaniesResult result = new GetCompaniesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetCompaniesResources.ResourceManager.GetString("Get_Title"),
                Message = GetCompaniesResources.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            try
            {
                result.Companies = await _companiesRepositories
                                         .GetCompanies(getCompaniesDto);

                if (!result.Companies.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetCompaniesResources.ResourceManager.GetString("Get_200_INFO_Message");

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

        public async Task<PutCompaniesResult> Update(PutCompaniesDto putCompaniesDto)
        {
            PutCompaniesResult result = new PutCompaniesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutCompaniesResources.ResourceManager.GetString("Put_Title"),
                Message = PutCompaniesResources.ResourceManager.GetString("Put_200_SUCCESS_Message")
            };

            try
            {
                //Validación de Actualizacion de la empresa
                PutCompaniesResult resultVlidations = await _companiesValidations
                                                            .PutCompaniesValid(putCompaniesDto);

                if (!resultVlidations.IsValid)
                {
                    return resultVlidations;
                }

                await _companiesRepositories
                      .UpdateCompany(putCompaniesDto);
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
