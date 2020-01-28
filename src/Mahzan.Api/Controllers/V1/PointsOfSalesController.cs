using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.PointOfSales;
using Mahzan.Business.Requests.PointOfSales;
using Mahzan.Business.Results.PointOfSales;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Filters.PointsOfSales;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PointsOfSalesController : BaseController
    {
        readonly IPointsOfSalesBusiness _pointOfSalesBusiness;

        public PointsOfSalesController(
            IMembersBusiness miembrosBusiness,
            IPointsOfSalesBusiness pointOfSalesBusiness)
            : base(miembrosBusiness)
        {
            _pointOfSalesBusiness = pointOfSalesBusiness;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostPointOfSalesRequest postPointOfSalesRequest)
        {
            PostPointOfSalesResult result = await _pointOfSalesBusiness
                                                   .Add(new AddPointsOfSalesDto()
                                                   {
                                                       Code = postPointOfSalesRequest.Code,
                                                       Name = postPointOfSalesRequest.Name,
                                                       StoreId = postPointOfSalesRequest.StoresId,
                                                       MembersId = MemberId,
                                                       AspNetUserId = AspNetUserId,
                                                       TableAuditEnum = TableAuditEnum.POINTSOFSALES_AUDIT
                                                   });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPointsOfSalesFilter getPointsOfSalesFilter)
        {
            GetPointsOfSalesResult result = await _pointOfSalesBusiness
                                                   .Get(getPointsOfSalesFilter);

            result.Paging = new Paging()
            {
                TotalCount = result.PointsOfSales.TotalCount,
                PageSize = result.PointsOfSales.PageSize,
                CurrentPage = result.PointsOfSales.CurrentPage,
                TotalPages = result.PointsOfSales.TotalPages,
                HasNext = result.PointsOfSales.HasNext,
                HasPrevious = result.PointsOfSales.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutPointsOfSalesRequest putPointsOfSalesRequest)
        {
            PutPointsOfSalesResult result = await _pointOfSalesBusiness
                                                   .Update(new PutPointsOfSalesDto
                                                   {
                                                       PointOfSalesId = putPointsOfSalesRequest.PointOfSalesId,
                                                       Code = putPointsOfSalesRequest.Code,
                                                       Name = putPointsOfSalesRequest.Name,
                                                       Active = putPointsOfSalesRequest.Active,
                                                       AspNetUserId = AspNetUserId,
                                                       TableAuditEnum = TableAuditEnum.POINTSOFSALES_AUDIT
                                                   });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid PointOfSaleId)
        {
            DeletePointsOfSalesResult result = await _pointOfSalesBusiness
                                                      .Delete(new DeletePointsOfSalesDto
                                                      {
                                                          PointOfSaleId = PointOfSaleId,
                                                          AspNetUserId = AspNetUserId,
                                                          TableAuditEnum = TableAuditEnum.POINTSOFSALES_AUDIT

                                                      });

            return StatusCode(result.StatusCode, result);
        }
    }
}
