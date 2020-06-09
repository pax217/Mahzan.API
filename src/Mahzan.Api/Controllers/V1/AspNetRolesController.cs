using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exeptions;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Results.AspNetRoles;
using Mahzan.Dapper.Repositories.AspNetRoles.GetAspNetRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AspNetRolesController : BaseController
    {
        private readonly IGetAspNetRolesRepository _getAspNetRolesRepository;

        public AspNetRolesController(
            IMembersBusiness membersBusiness,
            IGetAspNetRolesRepository getAspNetRolesRepository):
            base(membersBusiness)
        {
            _getAspNetRolesRepository = getAspNetRolesRepository;
        }



        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            GetAspNetRolesResult result = new GetAspNetRolesResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
            };


            try
            {
                result.AspNetRoles = await _getAspNetRolesRepository.Handle();
            }
            catch (KeyNotFoundException ex)
            {

                throw new ServiceKeyNotFoundException(ex);
            }

            return Ok(result);
        }

    }
}
