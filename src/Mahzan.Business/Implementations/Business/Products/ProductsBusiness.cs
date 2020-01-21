using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Interfaces.Validations.Products;
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

        readonly IAddProductsValidations _addProductsValidations;

        public ProductsBusiness(
            IMapper mapper,
            IProductsRepository productsRepository,
            IAddProductsValidations addProductsValidations)
        {
            _mapper = mapper;

            _productsRepository = productsRepository;

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


        #region Private Methods

        private async Task<Models.Entities.Products> AddProduct(AddProductsDto addProductsDto)
        {
            //Agrega el Producto
            return _productsRepository
                   .Add(addProductsDto);
        }

        private async Task<Models.Entities.Products_Store> AddProductsStore(
            Models.Entities.Products addedProduct,
            AddProductsDto addProductsDto)
        {
            Models.Entities.Products_Store result = null;

            if (addProductsDto.FollowInventory)
            {
                foreach (var item in addProductsDto.AddProductsStoreDto)
                {

                }
            }
            else
            {

            }

            return result;
        }

        #endregion
    }
}
