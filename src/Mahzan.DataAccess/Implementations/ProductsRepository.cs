using System;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductsRepository: RepositoryBase<Products>, IProductsRepository
    {
        public ProductsRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Products Delete(DeleteProductsDto deleteProductsDto)
        {
            throw new NotImplementedException();
        }

        public PagedList<Products> Get(GetProductsFilter getProductsFilter)
        {
            throw new NotImplementedException();
        }

        public Products Update(PutProductsDto putProductsDto)
        {
            throw new NotImplementedException();
        }
    }
}
