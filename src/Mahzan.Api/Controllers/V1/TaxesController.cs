using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Taxes.CreateTax;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exeptions;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Events.Taxes.CreateTax;
using Mahzan.Business.EventsHandlers.Taxes.CreateTax;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Business.Requests.Taxes;
using Mahzan.Business.Results.Taxes;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Filters.Taxes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TaxesController : BaseController
    {
        readonly ITaxesBusiness _taxesBusiness;

        private readonly ICreateTaxEventHandler _createTaxEventHandler;

        public TaxesController(
            IMembersBusiness miembrosBusiness,
            ITaxesBusiness taxesBusiness, 
            ICreateTaxEventHandler createTaxEventHandler)
            : base(miembrosBusiness)
        {
            _taxesBusiness = taxesBusiness;
            _createTaxEventHandler = createTaxEventHandler;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Post(CreateTaxCommand command)
        {
            CreateTaxResult result = new CreateTaxResult
            {
                IsValid= true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = $"Crea Impuesto",
                Message =$"Se ha creado correctamente el impuesto {command.Name} ."
            };

            try
            {
                await _createTaxEventHandler.Handle(new CreateTaxEvent
                {
                    Name = command.Name,
                    Type = command.Type,
                    TaxRateVariable = command.TaxRateVariable,
                    TaxRatePercentage = command.TaxRatePercentage,
                    Active = command.Active,
                    Printed = command.Printed,
                    MembersId = MembersId,
                    AspNetUserId = AspNetUserId
                });
            }
            catch (ServiceArgumentException ex)
            {
                throw new ServiceArgumentException(ex);
            }

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetWhere([FromQuery]GetTaxesFilter filter) 
        {

            GetTaxesResult result;

            try
            {
                result = await _taxesBusiness
                               .GetWhere(new GetTaxesDto
                               {
                                   TaxesId = filter.TaxesId,
                                   MembersId = MembersId
                               });
            }
            catch (KeyNotFoundException ex)
            {

                throw new ServiceKeyNotFoundException(ex);
            }

            return Ok(result);
        }
    }
}
