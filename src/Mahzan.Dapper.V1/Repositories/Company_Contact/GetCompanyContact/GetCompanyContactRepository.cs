using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Company_Contact.GetCompanyContact
{
    public class GetCompanyContactRepository : DataConnection,IGetCompanyContactRepository
    {
        public GetCompanyContactRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Company_Contact> GetByPointsOfSalesId(Guid pointsOfSalesId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from Company_Contact ");
            sql.Append("Inner Join Companies on Companies.CompaniesId = Company_Contact.CompaniesId ");
            sql.Append("Inner Join Stores on Stores.CompaniesId = Companies.CompaniesId ");
            sql.Append("Inner Join PointsOfSales on PointsOfSales.StoresId = Stores.StoresId ");
            sql.Append("where PointsOfSales.PointsOfSalesId = @PointsOfSalesId ");

            IEnumerable<Models.Entities.Company_Contact> companyContact;
            companyContact = await Connection
                .QueryAsync<Models.Entities.Company_Contact>(
                sql.ToString(),
                new
                {
                    PointsOfSalesId = pointsOfSalesId
                });

            return companyContact.FirstOrDefault();
        }
    }
}
