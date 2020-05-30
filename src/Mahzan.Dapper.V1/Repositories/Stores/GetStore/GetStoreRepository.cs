using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Stores.GetStore
{
    public class GetStoreRepository : DataConnection, IGetStoreRepository
    {
        public GetStoreRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.Stores> GetByPointsOfSales(Guid pointsOfSalesId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select ");
            sql.Append("        Stores.StoresId,");
            sql.Append("        Stores.Code,");
            sql.Append("        Stores.Name,");
            sql.Append("        Stores.Phone,");
            sql.Append("        Stores.Comment,");
            sql.Append("        Stores.MembersId ");
            sql.Append("from Stores ");
            sql.Append("Inner Join PointsOfSales on PointsOfSales.StoresId = Stores.StoresId ");
            sql.Append("where PointsOfSalesId = @pointsOfSalesId ");

            IEnumerable<Models.Entities.Stores> stores;
            stores = await Connection
                .QueryAsync<Models.Entities.Stores>(
                sql.ToString(),
                new
                {
                    PointsOfSalesId = pointsOfSalesId
                });

            return stores.FirstOrDefault();
        }

        public async Task<Models.Entities.Stores> GetByStoresId(Guid storesId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select * from Stores ");
            sql.Append("where StoresId = @StoresId ");

            IEnumerable<Models.Entities.Stores> taxes;
            taxes = await Connection
                .QueryAsync<Models.Entities.Stores>(
                sql.ToString(),
                new
                {
                    StoresId = storesId
                });

            return taxes.FirstOrDefault();
        }
    }
}
