
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Taxes.GetTax
{
    public class GetTaxRepository : DataConnection, IGetTaxRepository
    {
        public GetTaxRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Taxes> GetByTaxesId(Guid taxesId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select * from Taxes ");
            sql.Append("where TaxesId = @TaxesId ");

            IEnumerable<Models.Entities.Taxes> taxes;
            taxes = await Connection
                .QueryAsync<Models.Entities.Taxes>(
                sql.ToString(),
                new
                {
                    TaxesId = taxesId
                });

            return taxes.FirstOrDefault();
        }
    }
}
