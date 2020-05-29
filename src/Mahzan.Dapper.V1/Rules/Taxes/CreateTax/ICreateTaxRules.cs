using Mahzan.Dapper.DTO.Taxes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Rules.Taxes.CreateTax
{
    public interface ICreateTaxRules
    {
        Task Handle(CreateTaxDto createTaxDto);
    }
}
