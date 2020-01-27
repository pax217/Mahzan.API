using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.Groups;
using Mahzan.Business.Requests.Grupos;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GroupsController :BaseController
    {
        readonly IGroupsBusiness _groupsBusiness;

        public GroupsController(
            IMembersBusiness miembrosBusiness,
            IGroupsBusiness groupsBusiness
            ):base(miembrosBusiness)
        {
            _groupsBusiness = groupsBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(AddGroupsRequest addGroupsRequest)
        {

            AddGroupsResult result = await _groupsBusiness
                                            .Add(new AddGroupsDto()
                                            {
                                                Name = addGroupsRequest.Name,
                                                MembersId = MemberId,
                                                AspNetUserId = AspNetUserId,
                                                TableAuditEnum = TableAuditEnum.GROUPS_AUDIT,
                                            });

            return StatusCode(result.StatusCode,result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetGroupFilter getGroupFilter)
        {
            GetGroupsResult result = await _groupsBusiness
                                            .Get(new GetGroupsDto {
                                                GroupId = getGroupFilter.GroupId,
                                                Name = getGroupFilter.Name,
                                                MembersId = MemberId
                                            });

            result.Paging = new Paging()
            {
                TotalCount = result.Groups.TotalCount,
                PageSize = result.Groups.PageSize,
                CurrentPage = result.Groups.CurrentPage,
                TotalPages = result.Groups.TotalPages,
                HasNext = result.Groups.HasNext,
                HasPrevious = result.Groups.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutGroupsRequest putGroupsRequest)
        {
            PutGroupsResult result = await _groupsBusiness
                                            .Put(new PutGroupsDto()
                                            {
                                                GroupId = putGroupsRequest.GroupId,
                                                Name = putGroupsRequest.Name,
                                                Active = putGroupsRequest.Active,
                                                AspNetUserId = AspNetUserId,
                                                TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                            });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid groupId)
        {
            DeleteGroupsResult result = await _groupsBusiness
                                               .Delete(new DeleteGroupsDto()
                                               {
                                                   GroupId = groupId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.GROUPS_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }
    }
}
