using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.PointsOfSales.GetPointsOfSale
{
    public interface IGetPointsOfSaleRepository
    {
        Task<Models.Entities.PointsOfSales> GetByPointsOfSalesId(Guid pointsOfSalesId);
    }
}
