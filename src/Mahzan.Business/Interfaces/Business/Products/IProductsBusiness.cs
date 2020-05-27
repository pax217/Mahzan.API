using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;

namespace Mahzan.Business.Interfaces.Business.Products
{
    public interface IProductsBusiness
    {

        Task<GetProductsResult> Get(GetProductsDto getProductsDto);

        Task<PutProductsResult> Update(PutProductsDto putProductsDto);

        Task<DeleteProductsResult> Delete(DeleteProductsDto deleteProductsDto);
    }
}
