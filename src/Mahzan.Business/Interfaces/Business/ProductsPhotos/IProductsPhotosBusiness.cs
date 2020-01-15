using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.ProductsPhotos;
using Mahzan.DataAccess.DTO.ProductsPhotos;

namespace Mahzan.Business.Interfaces.Business.ProductsPhotos
{
    public interface IProductsPhotosBusiness
    {
        Task<PostProductsPhotosResult> Add(AddProductsPhotosDto addProductsPhotosDto);
    }
}
