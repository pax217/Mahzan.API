using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductCategories;
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

        public async Task<ProductCategories> Add(AddProductCategoriesDto addProductCategoriesDto)
        {
            ProductCategories newProductCategories = new ProductCategories
            {
                Description = addProductCategoriesDto.Description,
                Color = addProductCategoriesDto.Color,
                MemberId = addProductCategoriesDto.MembersId
            };

            _context.Set<ProductCategories>().Add(newProductCategories);
            await _context.SaveChangesAsync();

            return newProductCategories;
        }
    }
}
