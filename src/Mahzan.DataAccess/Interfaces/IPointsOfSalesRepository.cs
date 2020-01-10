using System;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Filters.PointsOfSales;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IPointsOfSalesRepository: IRepositoryBase<PointsOfSales>
    {
        PagedList<PointsOfSales> Get(GetPointsOfSalesFilter getPointsOfSalesFilter);

        PointsOfSales Update(PutPointsOfSalesDto putPointsOfSalesDto);

        PointsOfSales Delete(DeletePointsOfSalesDto deletePointsOfSalesDto);
    }
}
