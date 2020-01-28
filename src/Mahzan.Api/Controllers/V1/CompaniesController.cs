using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Requests.Companies;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        readonly ICompaniesBusiness _companiesBusiness;

        public CompaniesController(
            IMembersBusiness miembrosBusiness,
            ICompaniesBusiness companiesBusiness)
            : base(miembrosBusiness)
        {
            _companiesBusiness = companiesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostCompaniesRequest postCompaniesRequest)
        {
            AddCompaniesResult result = await _companiesBusiness
                                               .Add(new AddCompaniesDto()
                                               {
                                                   RFC = postCompaniesRequest.RFC,
                                                   CommercialName = postCompaniesRequest.CommercialName,
                                                   BusinessName = postCompaniesRequest.BusinessName,
                                                   Active = postCompaniesRequest.Active,
                                                   GrupoId = postCompaniesRequest.GroupId,
                                                   MembersId = MemberId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.COMPANIES_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCompaniesFilter getCompaniesFilter)
        {
            GetCompaniesResult result = await _companiesBusiness
                                               .Get(new GetCompaniesDto {
                                                   MembersId = MemberId,
                                                   BusinessName = getCompaniesFilter.BusinessName,
                                                   GroupsId = getCompaniesFilter.GroupsId
                                               });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutCompaniesRequest putCompaniesRequest)
        {
            PutCompaniesResult result = await _companiesBusiness
                                               .Update(new PutCompaniesDto()
                                               {
                                                   CompanyId = putCompaniesRequest.CompanyId,
                                                   RFC = putCompaniesRequest.RFC,
                                                   CommercialName = putCompaniesRequest.CommercialName,
                                                   BusinessName = putCompaniesRequest.BusinessName,
                                                   Active = putCompaniesRequest.Active,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.COMPANIES_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid companyId)
        {
            DeleteCompaniesResult result = await _companiesBusiness
                                                  .Delete(new DeleteCompaniesDto()
                                                  {
                                                      CompanyId = companyId,
                                                      AspNetUserId = AspNetUserId,
                                                      TableAuditEnum = TableAuditEnum.COMPANIES_AUDIT
                                                  });

            return StatusCode(result.StatusCode, result);
        }
    }
}