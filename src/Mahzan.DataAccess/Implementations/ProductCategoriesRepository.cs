using System;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductCategoriesRepository: RepositoryBase<ProductCategories>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
