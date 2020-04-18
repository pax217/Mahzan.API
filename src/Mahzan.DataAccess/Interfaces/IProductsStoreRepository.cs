using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductsStoreRepository: IRepositoryBase<Products_Store>
    {
        Task<Products_Store> Get(Guid productsStoreId,
                                 Guid storesId);

        Task<List<Products_Store>> Add(AddProductsStoreDto addProductsStoreDto);

        Task<Products_Store> Update(PutProductsStoreDto putProductsStoreDto);
    }
}
