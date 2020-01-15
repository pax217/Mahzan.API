using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Resources.Business.Products;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Products
{
    public class ProductsBusiness : IProductsBusiness
    {

        readonly IMapper _mapper;

        readonly IProductsRepository _productsRepository;

        public ProductsBusiness(
            IMapper mapper,
            IProductsRepository productsRepository)
        {
            _mapper = mapper;

            _productsRepository = productsRepository;
        }

        public async Task<PostProductsResult> Add(AddProductsDto addProductsDto)
        {
            PostProductsResult result = new PostProductsResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddProductsResources.ResourceManager.GetString("Add_Title"),
                Message = AddProductsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                _productsRepository
                    .Add(_mapper.Map<Models.Entities.Products>(addProductsDto),
                    addProductsDto.AspNetUserId,
                    addProductsDto.TableAuditEnum);

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

        public Task<GetProductsResult> Get(GetProductsFilter getProductsFilter)
        {
            throw new NotImplementedException();
        }

        public Task<PutProductsResult> Update(PutProductsDto putProductsDto)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteProductsResult> Update(DeleteProductsDto deleteProductsDto)
        {
            throw new NotImplementedException();
        }
    }
}
