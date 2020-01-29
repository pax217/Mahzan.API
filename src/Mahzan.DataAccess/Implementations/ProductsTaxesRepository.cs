using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductsTaxesRepository : RepositoryBase<ProductsTaxes>, IProductsTaxesRepository
    {
        public ProductsTaxesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<ProductsTaxes> Add(ProductsTaxesDto productsTaxesDto)
        {
            ProductsTaxes newProductsTaxes = new ProductsTaxes
            {
                ProductsId = productsTaxesDto.ProductsId,
                TaxesId = productsTaxesDto.TaxesId
            };

            _context.Set<ProductsTaxes>().Add(newProductsTaxes);
            await _context.SaveChangesAsync();

            return newProductsTaxes;
        }
    }
}
