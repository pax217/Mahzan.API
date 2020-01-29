using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductUnits;
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

        public async Task<ProductUnits> Add(AddProductUnitsDto addProductUnitsDto)
        {
            ProductUnits newProductUnits = new ProductUnits
            {
                Abbreviation = addProductUnitsDto.Abbreviation,
                Description = addProductUnitsDto.Description,
                MembersId = addProductUnitsDto.MembersId
            };

            _context.Set<ProductUnits>().Add(newProductUnits);
            await _context.SaveChangesAsync();

            return newProductUnits;
        }
    }
}
