using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.EmployeesStores;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.EmployeesStores;
using Mahzan.Business.Results.EmployeesStores;
using Mahzan.DataAccess.DTO.EmployeesStores;
using Mahzan.DataAccess.Filters.EmployeesStores;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesStoresController : BaseController
    {
        readonly IEmployeesStoresBusiness _employeesStoresBusiness;

        public EmployeesStoresController(
            IMembersBusiness membersBusiness,
            IEmployeesStoresBusiness employeesStoresBusiness)
            : base(membersBusiness)
        {
            _employeesStoresBusiness = employeesStoresBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostEmployeesStoresRequest postEmployeesStoresRequest)
        {
            PostEmployeesStoresResult result = await _employeesStoresBusiness
                                                      .Add(new AddEmployeesStoresDto
                                                      {
                                                          GroupId = postEmployeesStoresRequest.GroupId,
                                                          CompanyId = postEmployeesStoresRequest.CompanyId,
                                                          StoreId = postEmployeesStoresRequest.StoreId,
                                                          EmployeeId = postEmployeesStoresRequest.EmployeeId,
                                                          Active = postEmployeesStoresRequest.Active,
                                                          AspNetUserId = AspNetUserId,
                                                          MembersId = MembersId,
                                                          TableAuditEnum = TableAuditEnum.EMPLOYEES_STORES_AUDIT
                                                      });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEmployeesStoresFilter getEmployeesStoresFilter)
        {
            GetEmployeesStoresResult result = await _employeesStoresBusiness
                                                     .Get(new GetEmployeesStoresDto { 
                                                        EmployeesId = getEmployeesStoresFilter.EmployeesId,
                                                        MembersId = MembersId
                                                     });

            return StatusCode(result.StatusCode, result);
        }
    }
}
