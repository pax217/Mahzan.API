using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
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
                                                Active = addGroupsRequest.Active,
                                                MemberId = MemberId,
                                                AspNetUserId = AspNetUserId,
                                                TableAuditEnum = TableAuditEnum.GROUPS_AUDIT,
                                            });

            return StatusCode(result.StatusCode,result);
        }
    }
}
