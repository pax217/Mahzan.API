using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.PointsOfSales.GetPointsOfSale
{
    public class GetPointsOfSaleRepository : DataConnection, IGetPointsOfSaleRepository
    {
        public GetPointsOfSaleRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Models.Entities.PointsOfSales> GetByPointsOfSalesId(Guid pointsOfSalesId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("Select * from PointsOfSales ");
            sql.Append("where PointsOfSalesId = @PointsOfSalesId ");

            IEnumerable<Models.Entities.PointsOfSales> taxes;
            taxes = await Connection
                .QueryAsync<Models.Entities.PointsOfSales>(
                sql.ToString(),
                new
                {
                    PointsOfSalesId = pointsOfSalesId
                });

            return taxes.FirstOrDefault();
        }
    }
}
