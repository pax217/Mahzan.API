using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Companies.GetCompany
{
    public class GetCompanyRepository : DataConnection, IGetCompanyRepository
    {
        public GetCompanyRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Companies> GetByPointsOfSalesId(Guid pointsOfSalesId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select* from Companies ");
            sql.Append("Inner Join Stores on Stores.CompaniesId = Companies.CompaniesId ");
            sql.Append("Inner Join PointsOfSales on PointsOfSales.StoresId = Stores.StoresId ");
            sql.Append("where PointsOfSales.PointsOfSalesId = @PointsOfSalesId ");


            IEnumerable<Models.Entities.Companies> companies;
            companies = await Connection
                .QueryAsync<Models.Entities.Companies>(
                sql.ToString(),
                new {
                    PointsOfSalesId = pointsOfSalesId
                } );

            return companies.FirstOrDefault();
        }
    }
}
