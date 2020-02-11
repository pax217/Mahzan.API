using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.ProductCategories;
using Mahzan.Business.Resources.Business.ProductCategories;
using Mahzan.Business.Results.ProductCategories;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.ProductCategories
{
    public class ProductCategoriesBusiness: IProductCategoriesBusiness
    {
        readonly IProductCategoriesRepository _productCategoriesRepository;

        readonly IMapper _mapper;

        public ProductCategoriesBusiness(
            IProductCategoriesRepository productCategoriesRepository,
            IMapper mapper)
        {
            _productCategoriesRepository = productCategoriesRepository;

            _mapper = mapper;
        }

        public async Task<PostProductCategoriesResult> Add(AddProductCategoriesDto addProductCategoriesDto)
        {
            PostProductCategoriesResult result = new PostProductCategoriesResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddProductCategoriesResources.ResourceManager.GetString("Add_Title"),
                Message = AddProductCategoriesResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                //Valida información de la categoría

                //Agrega Categoría
                result.ProductCategory = await _productCategoriesRepository
                                               .Add(addProductCategoriesDto);

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

        public async Task<GetProductCategoriesResult> Get(GetProductsCategoriesDto getProductsCategoriesDto)
        {
            GetProductCategoriesResult result = new GetProductCategoriesResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetProductCategoriesResources.ResourceManager.GetString("Get_Title"),
                Message = GetProductCategoriesResources.ResourceManager.GetString("Get_200_SUCCESS_Message")

            };

            try
            {

                result.ProductCategories = _productCategoriesRepository
                                            .Get(getProductsCategoriesDto);

                if (!result.ProductCategories.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetProductCategoriesResources.ResourceManager.GetString("Get_200_INFO_Message");

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
