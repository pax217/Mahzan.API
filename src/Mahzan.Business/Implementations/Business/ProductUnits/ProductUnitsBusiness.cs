using System;
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
                _productUnitsRepository
                    .Add(_mapper.Map<Models.Entities.ProductUnits>(addProductUnitsDto),
                    addProductUnitsDto.AspNetUserId,
                    addProductUnitsDto.TableAuditEnum);
                       
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
