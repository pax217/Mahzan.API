using System;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductUnitsRepository: RepositoryBase<ProductUnits>, IProductUnitsRepository
    {
        public ProductUnitsRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
