using System;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductsStoreRepository: IRepositoryBase<Products_Store>
    {
        Products_Store Add(AddProductsStoreDto addProductsStoreDto);
    }
}
