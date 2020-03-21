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
        #region Properties

        readonly ICompaniesBusiness _companiesBusiness;

        #endregion

        #region Constructors
        public CompaniesController(
            IMembersBusiness miembrosBusiness,
            ICompaniesBusiness companiesBusiness)
            : base(miembrosBusiness)
        {
            _companiesBusiness = companiesBusiness;
        }

        #endregion

        #region Public Methods

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
                                                   GroupsId = postCompaniesRequest.GroupsId,
                                                   MembersId = MembersId,
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
                                               .Get(new GetCompaniesDto
                                               {
                                                   MembersId = MembersId,
                                                   CompaniesId = getCompaniesFilter.CompaniesId,
                                                   BusinessName = getCompaniesFilter.BusinessName
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
                                                   CompaniesId = putCompaniesRequest.CompaniesId,
                                                   RFC = putCompaniesRequest.RFC,
                                                   CommercialName = putCompaniesRequest.CommercialName,
                                                   BusinessName = putCompaniesRequest.BusinessName,
                                                   GroupsId = putCompaniesRequest.GroupsId,
                                                   AspNetUserId = AspNetUserId,
                                                   TableAuditEnum = TableAuditEnum.COMPANIES_AUDIT
                                               });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid companiesId)
        {
            DeleteCompaniesResult result = await _companiesBusiness
                                                  .Delete(new DeleteCompaniesDto()
                                                  {
                                                      CompaniesId = companiesId,
                                                      AspNetUserId = AspNetUserId,
                                                      TableAuditEnum = TableAuditEnum.COMPANIES_AUDIT
                                                  });

            return StatusCode(result.StatusCode, result);
        }

        #endregion
    }
}