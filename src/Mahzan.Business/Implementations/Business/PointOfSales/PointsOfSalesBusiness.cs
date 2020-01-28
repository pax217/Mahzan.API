using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.PointOfSales;
using Mahzan.Business.Interfaces.Validations.PointsOfSales;
using Mahzan.Business.Requests.PointOfSales;
using Mahzan.Business.Resources.Business.PointsOfSales;
using Mahzan.Business.Results.PointOfSales;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Filters.PointsOfSales;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.PointOfSales
{
    public class PointsOfSalesBusiness: IPointsOfSalesBusiness
    {
        readonly IPointsOfSalesRepository _pointsOfSalesRepository;

        readonly IPointsOfSalesValidations _pointsOfSalesValidations;

        readonly IMapper _mapper;

        public PointsOfSalesBusiness(
            IPointsOfSalesRepository pointsOfSalesRepository,
            IPointsOfSalesValidations pointsOfSalesValidations,
            IMapper mapper)
        {
            _pointsOfSalesRepository = pointsOfSalesRepository;

            _pointsOfSalesValidations = pointsOfSalesValidations;

            _mapper = mapper;
        }

        public async Task<PostPointOfSalesResult> Add(AddPointsOfSalesDto addPointOfSalesDto)
        {
            PostPointOfSalesResult result = new PostPointOfSalesResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddPointsOfSalesResources.ResourceManager.GetString("Add_Title"),
                Message = AddPointsOfSalesResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                //Validaciones
                PostPointOfSalesResult resultValidations = await _pointsOfSalesValidations
                                                                 .AddPointsOfSalesValid(addPointOfSalesDto);

                if (!resultValidations.IsValid)
                {
                    return resultValidations;
                }

                result.PointOfSale = _pointsOfSalesRepository
                                     .Add(addPointOfSalesDto);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<DeletePointsOfSalesResult> Delete(DeletePointsOfSalesDto deletePointsOfSalesDto)
        {
            DeletePointsOfSalesResult result = new DeletePointsOfSalesResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeletePointsOfSalesResources.ResourceManager.GetString("Delete_Title"),
                Message = DeletePointsOfSalesResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")

            };

            try
            {
                _pointsOfSalesRepository
                 .Delete(deletePointsOfSalesDto);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<GetPointsOfSalesResult> Get(GetPointsOfSalesDto getPointsOfSalesDto)
        {
            GetPointsOfSalesResult result = new GetPointsOfSalesResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetPointsOfSalesResources.ResourceManager.GetString("Get_Title"),
                Message = GetPointsOfSalesResources.ResourceManager.GetString("Get_200_SUCCESS_Message")

            };

            try
            {
                result.PointsOfSales = _pointsOfSalesRepository
                                        .Get(getPointsOfSalesDto);

                if (!result.PointsOfSales.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetPointsOfSalesResources.ResourceManager.GetString("Get_200_INFO_Message");

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<PutPointsOfSalesResult> Update(PutPointsOfSalesDto putPointsOfSalesDto)
        {
            PutPointsOfSalesResult result = new PutPointsOfSalesResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutPointsOfSalesResources.ResourceManager.GetString("Put_Title"),
                Message = PutPointsOfSalesResources.ResourceManager.GetString("Put_200_SUCCESS_Message")

            };

            try
            {
                _pointsOfSalesRepository
                 .Update(putPointsOfSalesDto);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
