using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Stores;
using Mahzan.Business.Requests.Stores;
using Mahzan.Business.Results.Stores;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Filters.Stores;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StoresController : BaseController
    {
        readonly IStoresBusiness _storesBusiness;

        public StoresController(
            IMembersBusiness membersBusiness,
            IStoresBusiness storesBusiness)
            : base(membersBusiness)
        {
            _storesBusiness = storesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(AddStoresRequest addStoresRequest)
        {
            AddStoresResult result = await _storesBusiness
                                          .Add(new AddStoresDto
                                          {
                                              Code = addStoresRequest.Code,
                                              Name = addStoresRequest.Name,
                                              Phone = addStoresRequest.Phone,
                                              Comment = addStoresRequest.Comment,
                                              Active = addStoresRequest.Active,
                                              CompanyId = addStoresRequest.CompanyId,
                                              MembersId = MemberId,
                                              AspNetUserId = AspNetUserId,
                                              TableAuditEnum = TableAuditEnum.STORES_AUDIT
                                          });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetStoresFilter getStoresFilter)
        {
            GetStoresResult result = await _storesBusiness
                                            .Get(new GetStoresDto {
                                                MembersId = MemberId,
                                                StoresId = getStoresFilter.StoresId,
                                                Name = getStoresFilter.Name,
                                                CompaniesId = getStoresFilter.CompaniesId
                                            });

            result.Paging = new Paging()
            {
                TotalCount = result.Stores.TotalCount,
                PageSize = result.Stores.PageSize,
                CurrentPage = result.Stores.CurrentPage,
                TotalPages = result.Stores.TotalPages,
                HasNext = result.Stores.HasNext,
                HasPrevious = result.Stores.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutStoresRequest putStoresRequest)
        {
            PutStoresResult result = await _storesBusiness
                                            .Update(new PutStoresDto
                                            {
                                                StoreId = putStoresRequest.StoreId,
                                                Code = putStoresRequest.Code,
                                                Name = putStoresRequest.Name,
                                                Phone = putStoresRequest.Phone,
                                                Comment = putStoresRequest.Comment,
                                                Active = putStoresRequest.Active,
                                                AspNetUserId = AspNetUserId,
                                                TableAuditEnum = TableAuditEnum.STORES_AUDIT
                                            });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid StoreId)
        {
            DeleteStoresResult result = await _storesBusiness
                                               .Delete(new DeleteStoresDto
                                               {
                                                   StoreId = StoreId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.STORES_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }
    }
}
