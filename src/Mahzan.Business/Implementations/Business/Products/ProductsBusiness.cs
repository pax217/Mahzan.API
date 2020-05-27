using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Products;
using Mahzan.Business.Interfaces.Business.Products.Add;
using Mahzan.Business.Interfaces.Validations.Products;
using Mahzan.Business.Resources.Business.Products;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Products
{
    public class ProductsBusiness : IProductsBusiness
    {
        #region Properties

        //Repositories
        readonly IProductsRepository _productsRepository;
        private readonly IGetProductCommercialMaginService _getProductCommercialMaginService; 

        readonly IProductsStoreRepository _productsStoreRepository;
        readonly IProductsTaxesRepository _productsTaxesRepository;
        readonly IStoresRepository _storesRepository;
        readonly IProductsPhotosRepository _productsPhotosRepository;

        //Validations
        readonly IAddProductsValidations _addProductsValidations;

        //Services
        readonly IMapper _mapper;

        #endregion

        #region Constructors

        public ProductsBusiness(
            IProductsRepository productsRepository,
            IProductsStoreRepository productsStoreRepository,
            IProductsTaxesRepository productsTaxesRepository,
            IStoresRepository storesRepository,
            IAddProductsValidations addProductsValidations,
            IProductsPhotosRepository productsPhotosRepository,
            IGetProductCommercialMaginService getProductCommercialMaginService,
            IMapper mapper)
        {

            //Repositories
            _productsRepository = productsRepository;
            _productsStoreRepository = productsStoreRepository;
            _productsTaxesRepository = productsTaxesRepository;
            _storesRepository = storesRepository;
            _productsPhotosRepository = productsPhotosRepository;
            _getProductCommercialMaginService = getProductCommercialMaginService;

            //Validations
            _addProductsValidations = addProductsValidations;

            //Servcies
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

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



                //Agrega Producto
                AddProductsDto addProductsDtoWithCommercialMargin;
                addProductsDtoWithCommercialMargin = _getProductCommercialMaginService
                                                     .GetCommercialMargin(addProductsDto);

                result.Product = await  _productsRepository
                                        .Add(addProductsDtoWithCommercialMargin);

                if (result.Product != null)
                {
                    //Agrega Imagen de Producto

                    addProductsDto.AddProductPhotoDto.ProductsId = result.Product.ProductsId;

                    AddProductPhoto(addProductsDto.AddProductPhotoDto);
                }



                //Agrega Impuesto a Producto
                await AddProductsTaxes(result.Product,
                                 addProductsDto);

                //Agrega el Producto a seguimiento de Inventario
                //AddProductsStore(addedProduct, addProductsDto);

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
                result.Products =await _productsRepository
                                       .Get(getProductsDto);

                if (!result.Products.Any())
                {
                    result.IsValid = false;
                    result.StatusCode = 404;
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

        #endregion

        #region Private Methods

        //private async Task<Models.Entities.Products> AddProduct(AddProductsDto addProductsDto)
        //{
        //    //Agrega el Producto
        //    return _productsRepository
        //            .Add(addProductsDto);
        //}

        private void AddProductsStore(
            Models.Entities.Products addedProduct,
            AddProductsDto addProductsDto)
        {

            //if (addProductsDto.AvailableInAllStores)
            //{
            //    List<Models.Entities.Stores> Stores = _storesRepository
            //                                           .Get(x => x.MembersId == addProductsDto.MembersId);

            //    foreach (var store in Stores)
            //    {
            //        _productsStoreRepository.Add(new AddProductsStoreDto
            //        {
            //            Price = addProductsDto.Price.Value,
            //            StoresId = store.StoresId,
            //            ProductsId = addedProduct.ProductsId
            //        });
            //    }

            //}
            //else
            //{
            //    foreach (var addProductStoreDto in addProductsDto.AddProductsStoreDto)
            //    {
            //        addProductStoreDto.ProductsId = addedProduct.ProductsId;

            //        _productsStoreRepository.Add(addProductStoreDto);
            //    }
            //}

        }

        private async Task AddProductsTaxes(Models.Entities.Products addedProduct,
                                      AddProductsDto addProductsDto)
        {
            foreach (var tax in addProductsDto.AddProductTaxesDto)
            {

                await _productsTaxesRepository.Add(new AddProductsTaxesDto
                {
                    ProductsId = addedProduct.ProductsId,
                    TaxRate = tax.TaxRate,
                    TaxesId = tax.TaxesId,
                    MembersId = addProductsDto.MembersId
                });

            }
        }

        private void AddProductPhoto(AddProductPhotoDto addProductPhotoDto)
        {
            _productsPhotosRepository.Add(new Models.Entities.ProductsPhotos
            {
                Title = addProductPhotoDto.Title,
                DateTime = DateTime.Now,
                MIMEType = addProductPhotoDto.MIMEType,
                Base64 = addProductPhotoDto.Base64,
                ProductsId = addProductPhotoDto.ProductsId
            });
                  
        }

        public async Task<DeleteProductsResult> Delete(DeleteProductsDto deleteProductsDto)
        {
            DeleteProductsResult result = new DeleteProductsResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteProductsResources.ResourceManager.GetString("Delete_Title"),
                Message = DeleteProductsResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")

            };

            try
            {
                await _productsRepository
                      .Delete(deleteProductsDto);

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

        #endregion
    }
}
