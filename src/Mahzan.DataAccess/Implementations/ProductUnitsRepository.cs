using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductUnits;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;

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

        public PagedList<ProductUnits> Get(GetProductUnitsDto getProductUnitsDto)
        {
            List<ProductUnits> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getProductUnitsDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductUnits).GetProperties()
                    .First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductUnitsDto.MembersId
                });
            }

            if (getProductUnitsDto.Description != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductUnits).GetProperties()
                    .First(p => p.Name == "Description"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductUnitsDto.Description
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<ProductUnits>(filterExpressions).Compile();

                result = _context.Set<ProductUnits>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<ProductUnits>().ToList();
            }

            return PagedList<ProductUnits>.ToPagedList(result,
                                                       getProductUnitsDto.PageNumber,
                                                       getProductUnitsDto.PageSize);
        }
    }
}
