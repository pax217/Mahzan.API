using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductsTaxesRepository : RepositoryBase<ProductsTaxes>, IProductsTaxesRepository
    {
        public ProductsTaxesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<ProductsTaxes> Add(AddProductsTaxesDto productsTaxesDto)
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

        public async Task<PagedList<ProductsTaxes>> Get(GetProductsTaxesDto getProductsTaxesDto)
        {
            List<ProductsTaxes> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            //MembersId
            if (getProductsTaxesDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductsTaxes).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsTaxesDto.MembersId
                });
            }

            //ProductsId
            if (getProductsTaxesDto.ProductsId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductsTaxes).GetProperties().First(p => p.Name == "ProductsId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsTaxesDto.ProductsId
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<ProductsTaxes>(filterExpressions).Compile();

                result = _context.Set<ProductsTaxes>()
                                 .Include(t => t.Taxes)
                                 .Where(deleg)
                                 .ToList();
            }
            else
            {
                result = _context.Set<ProductsTaxes>()
                                 .Include(t => t.Taxes)
                                 .ToList();
            }

            return PagedList<ProductsTaxes>.ToPagedList(result,
                                                    getProductsTaxesDto.PageNumber,
                                                    getProductsTaxesDto.PageSize);

        }
    }
}
