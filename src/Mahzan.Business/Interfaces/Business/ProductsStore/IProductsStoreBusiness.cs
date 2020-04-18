using Mahzan.Business.Results.ProductsStore;
using Mahzan.DataAccess.DTO.ProductsStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Business.ProductsStore
{
    public interface IProductsStoreBusiness
    {
        Task<PostProductsStoreResult> Add(AddProductsStoreDto addProductsStoreDto);
    }
}
