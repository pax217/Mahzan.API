using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.EmployeesStores;
using Mahzan.Business.Resources.Business.EmployeesStores;
using Mahzan.Business.Results.EmployeesStores;
using Mahzan.DataAccess.DTO.EmployeesStores;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Filters.EmployeesStores;
using Mahzan.DataAccess.Filters.Stores;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.EmployeesStores
{
    public class EmployeesStoresBusiniess : IEmployeesStoresBusiness
    {
        readonly IEmployeesStoresRepository _employeesStoresRepository;

        readonly IStoresRepository _storesRepository;

        readonly IMapper _mapper;

        public EmployeesStoresBusiniess(
            IEmployeesStoresRepository employeesStoresRepository,
            IStoresRepository storesRepository,
            IMapper mapper)
        {
            _employeesStoresRepository = employeesStoresRepository;

            _storesRepository = storesRepository;

            _mapper = mapper;
        }

        public async Task<PostEmployeesStoresResult> Add(AddEmployeesStoresDto addEmployeesStoresDto)
        {
            PostEmployeesStoresResult result = new PostEmployeesStoresResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddEmployeesStoresResources.ResourceManager.GetString("Add_Title"),
                Message = AddEmployeesStoresResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                _employeesStoresRepository
                    .Add(_mapper.Map<Models.Entities.Employees_Stores>(addEmployeesStoresDto),
                         addEmployeesStoresDto.AspNetUserId,
                         addEmployeesStoresDto.TableAuditEnum);
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

        public async Task<GetEmployeesStoresResult> Get(GetEmployeesStoresFilter getEmployeesStoresFilter)
        {
            GetEmployeesStoresResult result = new GetEmployeesStoresResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetEmployeesStoresResources.ResourceManager.GetString("Get_Title"),
                Message = GetEmployeesStoresResources.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            try
            {
                List<Models.Entities.Employees_Stores> employees_Stores = _employeesStoresRepository
                                                                             .Get(getEmployeesStoresFilter);

                if (!employees_Stores.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetEmployeesStoresResources.ResourceManager.GetString("Get_200_INFO_Message");

                    return result;
                }
                else
                {
                    result.Stores = new List<Models.Entities.Stores>();

                    foreach (var employee_store in employees_Stores)
                    {
                        Models.Entities.Stores storeFind = _storesRepository
                                                            .Get(new GetStoresDto
                                                            {
                                                                StoresId = employee_store.StoreId
                                                            }).FirstOrDefault();
                        if (storeFind!=null)
                        {
                            result.Stores.Add(storeFind);
                        }

                    }
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
    }
}
