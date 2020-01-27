using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Interfaces.Validations.Products;
using Mahzan.Business.Resources.Business.Products;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Products
{
    public class ProductsBusiness : IProductsBusiness
    {

        readonly IMapper _mapper;

        readonly IProductsRepository _productsRepository;

        readonly IProductsStoreRepository _productsStoreRepository;

        readonly IAddProductsValidations _addProductsValidations;

        readonly IStoresRepository _storesRepository;

        public ProductsBusiness(
            IMapper mapper,
            IProductsRepository productsRepository,
            IProductsStoreRepository productsStoreRepository,
            IAddProductsValidations addProductsValidations,
            IStoresRepository storesRepository)
        {
            _mapper = mapper;

            _productsRepository = productsRepository;
            _productsStoreRepository = productsStoreRepository;

            _storesRepository = storesRepository;

            _addProductsValidations = addProductsValidations;
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
                //Validaciones de Producto
                PostProductsResult resultAddValidations = await _addProductsValidations
                                                                .AddProductsValid(addProductsDto);
                if (!resultAddValidations.IsValid)
                {
                    return resultAddValidations;
                }

                //agrega Producto
                Models.Entities.Products addedProduct = await AddProduct(addProductsDto);

                //Agrega el Producto a seguimiento de Inventario
                await AddProductsStore(addedProduct, addProductsDto);

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

        public async Task<GetProductsResult> Get(GetProductsDto getProductsDto)
        {
            GetProductsResult result = new GetProductsResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetProductsResources.ResourceManager.GetString("Get_Title"),
                Message = GetProductsResources.ResourceManager.GetString("Get_200_SUCCESS_Message")

            };

            try
            {
                result.Products = _productsRepository
                                   .Get(getProductsDto);

                if (result.Products == null)
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetProductsResources.ResourceManager.GetString("Get_200_INFO_Message");

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

        public Task<PutProductsResult> Update(PutProductsDto putProductsDto)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteProductsResult> Update(DeleteProductsDto deleteProductsDto)
        {
            throw new NotImplementedException();
        }


        #region Private Methods

        private async Task<Models.Entities.Products> AddProduct(AddProductsDto addProductsDto)
        {
            //Agrega el Producto
            return _productsRepository
                    .Add(addProductsDto);
        }

        private async Task AddProductsStore(
            Models.Entities.Products addedProduct,
            AddProductsDto addProductsDto)
        {

            if (addProductsDto.AvailableInAllStores)
            {
                List<Models.Entities.Stores> Stores = _storesRepository
                                                       .Get(x => x.MemberId == addProductsDto.MembersId);

                foreach (var store in Stores)
                {
                    _productsStoreRepository.Add(new AddProductsStoreDto
                    {
                        Price = addProductsDto.Price.Value,
                        StoresId = store.Id,
                        ProductsId = addedProduct.Id
                    });
                }

            }
            else
            {
                foreach (var addProductStoreDto in addProductsDto.AddProductsStoreDto)
                {
                    addProductStoreDto.ProductsId = addedProduct.Id;

                    _productsStoreRepository.Add(addProductStoreDto);
                }
            }

        }

        #endregion
    }
}
