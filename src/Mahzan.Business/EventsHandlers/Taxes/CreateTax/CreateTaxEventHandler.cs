using Mahzan.Business.Events.Taxes.CreateTax;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Repositories.Taxes.CreateTax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Taxes.CreateTax
{
    public class CreateTaxEventHandler : ICreateTaxEventHandler
    {
        private readonly ICreateTaxRepository _createTaxRepository;

        public CreateTaxEventHandler(
            ICreateTaxRepository createTaxRepository)
        {
            _createTaxRepository = createTaxRepository;
        }

        public async Task Handle(CreateTaxEvent createTaxEvent)
        {
            await _createTaxRepository
                .Handle(new CreateTaxDto
                {
                    Name = createTaxEvent.Name,
                    Type = createTaxEvent.Type,
                    TaxRateVariable = createTaxEvent.TaxRateVariable,
                    TaxRatePercentage = createTaxEvent.TaxRatePercentage,
                    Active = createTaxEvent.Active,
                    Printed = createTaxEvent.Printed,
                    MembersId = createTaxEvent.MembersId,
                    AspNetUserId = createTaxEvent.AspNetUserId
                });
        }
    }
}
