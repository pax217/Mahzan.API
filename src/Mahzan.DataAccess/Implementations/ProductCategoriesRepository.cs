using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public  PagedList<ProductCategories> Get(GetProductsCategoriesDto getProductsCategoriesDto)
        {
            List<ProductCategories> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getProductsCategoriesDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductCategories).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsCategoriesDto.MembersId
                });
            }

            if (getProductsCategoriesDto.Description != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductCategories).GetProperties().First(p => p.Name == "Description"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsCategoriesDto.Description
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<ProductCategories>(filterExpressions).Compile();

                result = _context.Set<ProductCategories>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<ProductCategories>().ToList();
            }

            return PagedList<ProductCategories>.ToPagedList(result,
                                                 getProductsCategoriesDto.PageNumber,
                                                 getProductsCategoriesDto.PageSize);
        }
    }
}
