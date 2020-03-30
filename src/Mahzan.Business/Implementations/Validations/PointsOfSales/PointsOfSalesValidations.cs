using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.PointsOfSales;
using Mahzan.Business.Resources.Validations.PointsOfSales;
using Mahzan.Business.Results.PointOfSales;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.PointsOfSales
{
    public class PointsOfSalesValidations: IPointsOfSalesValidations
    {
        readonly IPointsOfSalesRepository _pointsOfSalesRepository;

        public PointsOfSalesValidations(
            IPointsOfSalesRepository pointsOfSalesRepository)
        {
            _pointsOfSalesRepository = pointsOfSalesRepository;
        }

        public async Task<PostPointOfSalesResult> AddPointsOfSalesValid(AddPointsOfSalesDto addPointsOfSalesDto)
        {
            PostPointOfSalesResult result = new PostPointOfSalesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddPointsOfSalesValidationsResources.ResourceManager.GetString("Add_Valid_Title"),
                Message = AddPointsOfSalesValidationsResources.ResourceManager.GetString("Add_Valid_200_SUCCESS_Message")
            };

            //Valida el Nombre del punto de venta dentro de la misma tienda.
            PagedList<Models.Entities.PointsOfSales> pointsOfSalesName = await _pointsOfSalesRepository
                                                                         .Get(new GetPointsOfSalesDto
                                                                         {
                                                                             StoresId = addPointsOfSalesDto.StoresId,
                                                                             Name = addPointsOfSalesDto.Name,

                                                                         });

            if (pointsOfSalesName.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddPointsOfSalesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_Name_No_Valid");

                return result;
            }

            //Valida el Codigo del punto de venta dentro de la misma tienda.
            PagedList<Models.Entities.PointsOfSales> pointsOfSalesCode = await _pointsOfSalesRepository
                                                                         .Get(new GetPointsOfSalesDto
                                                                         {
                                                                             StoresId = addPointsOfSalesDto.StoresId,
                                                                             Code = addPointsOfSalesDto.Code,
                                                                         });
            if (pointsOfSalesCode.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddPointsOfSalesValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_Code_No_Valid");

                return result;
            }

            return result;
        }
    }
}
