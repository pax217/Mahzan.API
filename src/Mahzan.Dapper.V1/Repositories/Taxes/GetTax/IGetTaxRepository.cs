using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Taxes.GetTax
{
    public interface IGetTaxRepository
    {
        Task<Models.Entities.Taxes> GetByTaxesId(Guid taxesId);
    }
}
