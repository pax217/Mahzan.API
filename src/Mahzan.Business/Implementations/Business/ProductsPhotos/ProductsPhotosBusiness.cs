using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.ProductsPhotos;
using Mahzan.Business.Resources.Business.ProductsPhotos;
using Mahzan.Business.Results.ProductsPhotos;
using Mahzan.DataAccess.DTO.ProductsPhotos;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.ProductsPhotos
{
    public class ProductsPhotosBusiness : IProductsPhotosBusiness
    {
        readonly IProductsPhotosRepository _productsPhotosRepository;

        readonly IMapper _mapper;

        public ProductsPhotosBusiness(
            IProductsPhotosRepository productsPhotosRepository,
            IMapper mapper)
        {
            _productsPhotosRepository = productsPhotosRepository;

            _mapper = mapper;
        }

        public async Task<PostProductsPhotosResult> Add(AddProductsPhotosDto addProductsPhotosDto)
        {
            PostProductsPhotosResult result = new PostProductsPhotosResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddProductsPhotosResources.ResourceManager.GetString("Add_Title"),
                Message = AddProductsPhotosResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                _productsPhotosRepository
                    .Add(_mapper.Map<Models.Entities.ProductsPhotos>(addProductsPhotosDto));
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
