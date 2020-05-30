using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Stores.GetStore
{
    public interface IGetStoreRepository
    {
        Task<Models.Entities.Stores> GetByStoresId(Guid storesId);

        Task<Models.Entities.Stores> GetByPointsOfSales(Guid pointsOfSalesId);
    }
}
