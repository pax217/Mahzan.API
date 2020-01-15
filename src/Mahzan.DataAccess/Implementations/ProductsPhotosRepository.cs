using System;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductsPhotosRepository: RepositoryBase<ProductsPhotos>, IProductsPhotosRepository
    {
        public ProductsPhotosRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
