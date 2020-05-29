using Mahzan.Dapper.DTO.Taxes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Taxes.CreateTax
{
    public interface ICreateTaxRepository
    {
        Task Handle(CreateTaxDto createTaxDto);
    }
}
