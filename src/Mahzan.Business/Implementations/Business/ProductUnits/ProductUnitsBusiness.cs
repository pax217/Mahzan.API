using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.ProductUnits;
using Mahzan.Business.Resources.Business.ProductUnits;
using Mahzan.Business.Results.ProductUnits;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.DataAccess.DTO.ProductUnits;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.ProductUnits
{
    public class ProductUnitsBusiness:IProductUnitsBusiness
    {
        readonly IProductUnitsRepository _productUnitsRepository;

        readonly IMapper _mapper;

        public ProductUnitsBusiness(
            IProductUnitsRepository productUnitsRepository,
            IMapper mapper)
        {
            _productUnitsRepository = productUnitsRepository;

            _mapper = mapper;
        }

        public async Task<PostProductUnitsResult> Add(AddProductUnitsDto addProductUnitsDto)
        {
            PostProductUnitsResult result = new PostProductUnitsResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddProductUnitsResources.ResourceManager.GetString("Add_Title"),
                Message = AddProductUnitsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                result.ProductUnit = await _productUnitsRepository
                                           .Add(addProductUnitsDto);
                       
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

        public async Task<GetGetProductUnitsResult> Get(GetProductUnitsDto getProductUnitsDto)
        {
            GetGetProductUnitsResult result = new GetGetProductUnitsResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetProductUnitsResources.ResourceManager.GetString("Get_Title"),
                Message = GetProductUnitsResources.ResourceManager.GetString("Get_200_SUCCESS_Message")

            };

            try
            {

                result.ProductUnits =  _productUnitsRepository
                                        .Get(getProductUnitsDto);

                if (!result.ProductUnits.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetProductUnitsResources.ResourceManager.GetString("Get_200_INFO_Message");

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
    }
}
