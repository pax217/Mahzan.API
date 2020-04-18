using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.ProductsStore;
using Mahzan.Business.Resources.Business.ProductsStore;
using Mahzan.Business.Results.ProductsStore;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Business.ProductsStore
{
    public class ProductsStoreBusiness : IProductsStoreBusiness
    {
        private readonly IProductsStoreRepository _productsStoreRepository;

        public ProductsStoreBusiness(
            IProductsStoreRepository productsStoreRepository) 
        {
            _productsStoreRepository = productsStoreRepository;
        }

        public async Task<PostProductsStoreResult> Add(AddProductsStoreDto addProductsStoreDto)
        {
            PostProductsStoreResult result = new PostProductsStoreResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddProductsStoreResource.ResourceManager.GetString("Add_Title"),
                Message = AddProductsStoreResource.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };


            await _productsStoreRepository
                    .Add(addProductsStoreDto);



            return result;
        }
    }
}
