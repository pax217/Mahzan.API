using System;
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
                _productCategoriesRepository
                    .Add(_mapper.Map<Models.Entities.ProductCategories>(addProductCategoriesDto),
                    addProductCategoriesDto.AspNetUserId,
                    addProductCategoriesDto.TableAuditEnum);

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
