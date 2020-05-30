using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Company_Adress.GetCompanyAdress
{
    public class GetCompanyAdressRepository : DataConnection, IGetCompanyAdressRepository
    {
        public GetCompanyAdressRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Company_Adress> GetByPointsOfSalesId(
            Guid pointsOfSalesId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from Company_Adress ");
            sql.Append("Inner Join Companies on Companies.CompaniesId = Company_Adress.CompaniesId ");
            sql.Append("Inner Join Stores on Stores.CompaniesId = Companies.CompaniesId ");
            sql.Append("Inner Join PointsOfSales on PointsOfSales.StoresId = Stores.StoresId ");
            sql.Append("where PointsOfSales.PointsOfSalesId = @PointsOfSalesId ");

            IEnumerable<Models.Entities.Company_Adress> companyAdress;
            companyAdress = await Connection
                .QueryAsync<Models.Entities.Company_Adress>(
                sql.ToString(),
                new
                {
                    PointsOfSalesId = pointsOfSalesId
                });

            return companyAdress.FirstOrDefault();
        }
    }
}
