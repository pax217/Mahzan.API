using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductsRepository: IRepositoryBase<Products>
    {
        Task<Products> Add(AddProductsDto addProductsDto);

        Task<PagedList<Products>> Get(GetProductsDto getProductsDto);

        Task<Products> Update(PutProductsDto putProductsDto);

        Task<Products> Delete(DeleteProductsDto deleteProductsDto);
    }
}
