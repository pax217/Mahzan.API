using System;
using System.Threading.Tasks;
using Mahzan.Business.Requests.PointOfSales;
using Mahzan.Business.Results.PointOfSales;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Filters.PointsOfSales;

namespace Mahzan.Business.Interfaces.Business.PointOfSales
{
    public interface IPointsOfSalesBusiness
    {
        Task<PostPointOfSalesResult> Add(AddPointsOfSalesDto addPointOfSalesDto);

        Task<GetPointsOfSalesResult> Get(GetPointsOfSalesFilter getPointsOfSalesFilter);

        Task<PutPointsOfSalesResult> Update(PutPointsOfSalesDto putPointsOfSalesDto);

        Task<DeletePointsOfSalesResult> Delete(DeletePointsOfSalesDto deletePointsOfSalesDto);
    }
}
