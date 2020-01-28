using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.PointOfSales;
using Mahzan.DataAccess.DTO.PointOfSales;

namespace Mahzan.Business.Interfaces.Validations.PointsOfSales
{
    public interface IPointsOfSalesValidations
    {
        Task<PostPointOfSalesResult> AddPointsOfSalesValid(AddPointsOfSalesDto addPointsOfSalesDto);
    }
}
