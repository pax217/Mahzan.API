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
                MembersId = addProductCategoriesDto.MembersId
            };

            _context.Set<ProductCategories>().Add(newProductCategories);
            await _context.SaveChangesAsync();

            return newProductCategories;
        }

        public async Task<ProductCategories> Delete(DeleteProductsCategoriesDto deleteProductsCategoriesDto)
        {
            ProductCategories productCategoriesToDelte = (from g in _context.Set<ProductCategories>()
                                                where g.ProductCategoriesId.Equals(deleteProductsCategoriesDto.ProductCategoriesId)
                                                select g)
                                    .FirstOrDefault();

            _context.Set<ProductCategories>().Remove(productCategoriesToDelte);
            _context.SaveChangesAsync(deleteProductsCategoriesDto.TableAuditEnum,
                                      deleteProductsCategoriesDto.AspNetUserId);

            return productCategoriesToDelte;
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

            if (getProductsCategoriesDto.ProductCategoriesId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductCategories).GetProperties().First(p => p.Name == "ProductCategoriesId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsCategoriesDto.ProductCategoriesId
                });
            }

            if (getProductsCategoriesDto.Description != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductCategories).GetProperties().First(p => p.Name == "Description"),
                    Operator = OperationsEnum.Contains,
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

        public async Task<ProductCategories> Update(PutProductCategoriesDto putProductCategoriesDto)
        {
            ProductCategories productCategoriesToUpdate = (from g in _context.Set<ProductCategories>()
                                                 where g.ProductCategoriesId.Equals(putProductCategoriesDto.ProductCategoriesId)
                                                 select g)
                                               .FirstOrDefault();

            //Description
            if (putProductCategoriesDto.Description != null)
            {
                productCategoriesToUpdate.Description = putProductCategoriesDto.Description;
            }

            //Color
            if (putProductCategoriesDto.Color != null)
            {
                productCategoriesToUpdate.Color = putProductCategoriesDto.Color;
            }

            EntityEntry entry = _context.Entry(productCategoriesToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("ProductCategoriesId").IsModified = false;

            _context.Set<ProductCategories>().Update(productCategoriesToUpdate);
            _context.SaveChangesAsync(putProductCategoriesDto.TableAuditEnum,
                                      putProductCategoriesDto.AspNetUserId);

            return productCategoriesToUpdate;
        }
    }
}
