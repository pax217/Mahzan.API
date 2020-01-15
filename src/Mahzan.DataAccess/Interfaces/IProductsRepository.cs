using System;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductsRepository: IRepositoryBase<Products>
    {
        PagedList<Products> Get(GetProductsFilter getProductsFilter);

        Products Update(PutProductsDto putProductsDto);

        Products Delete(DeleteProductsDto deleteProductsDto);
    }
}
