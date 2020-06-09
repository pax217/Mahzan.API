using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Employees;
using Mahzan.Business.Requests.Employees;
using Mahzan.Business.Resources.Business.Employees;
using Mahzan.Business.Results.Employees;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Filters.Employees;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Employees
{
    public class EmployeesBusiness: IEmployeesBusiness
    {
        readonly IEmployeesRepository _employeesRepository;

        readonly IMapper _mapper;

        public EmployeesBusiness(
            IEmployeesRepository employeesRepository,
            IMapper mapper
            )
        {
            _employeesRepository = employeesRepository;

            _mapper = mapper;
        }

        public async Task<CreateEmployeeResult> Add(AddEmployeesDto addEmployeesDto)
        {
            CreateEmployeeResult result = new CreateEmployeeResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddEmployeesResources.ResourceManager.GetString("Add_Title"),
                Message = AddEmployeesResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al agregar un Empleado
                await _employeesRepository
                      .Add(addEmployeesDto);
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

        public async Task<DeleteEmployeesResult> Delete(DeleteEmployeesDto deleteEmployeesDto)
        {
            DeleteEmployeesResult result = new DeleteEmployeesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteEmployeesResources.ResourceManager.GetString("Delete_Title"),
                Message = DeleteEmployeesResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al 

                result.Employee = _employeesRepository
                                  .Delete(deleteEmployeesDto);
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

        public async Task<GetEmployeesResult> Get(GetEmployeesDto getEmployeesDto)
        {
            GetEmployeesResult result = new GetEmployeesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetEmployeesResources.ResourceManager.GetString("Get_Title"),
                Message = GetEmployeesResources.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            try
            {
                result.Employees = _employeesRepository
                                    .Get(getEmployeesDto);
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

        public async Task<PutEmployeesResult> Update(PutEmployeesDto putEmployeesDto)
        {
            PutEmployeesResult result = new PutEmployeesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutEmployeesResources.ResourceManager.GetString("Get_Title"),
                Message = PutEmployeesResources.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            try
            {
                _employeesRepository
                 .Update(putEmployeesDto);
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
