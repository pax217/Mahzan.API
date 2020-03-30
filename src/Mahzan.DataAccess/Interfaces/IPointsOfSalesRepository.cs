using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Filters.PointsOfSales;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IPointsOfSalesRepository: IRepositoryBase<PointsOfSales>
    {
        PointsOfSales Add(AddPointsOfSalesDto addPointsOfSalesDto);

        Task<PagedList<PointsOfSales>> Get(GetPointsOfSalesDto getPointsOfSalesDto);

        PointsOfSales Update(PutPointsOfSalesDto putPointsOfSalesDto);

        PointsOfSales Delete(DeletePointsOfSalesDto deletePointsOfSalesDto);
    }
}
