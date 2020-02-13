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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<ProductUnits> Delete(DeleteProductUnitsDto deleteProductUnitsDto)
        {
            ProductUnits productUnitsToDelte = (from g in _context.Set<ProductUnits>()
                                   where g.ProductUnitsId.Equals(deleteProductUnitsDto.ProductUnitsId)
                                   select g)
                                    .FirstOrDefault();

            _context.Set<ProductUnits>().Remove(productUnitsToDelte);
            _context.SaveChangesAsync(deleteProductUnitsDto.TableAuditEnum,
                                            deleteProductUnitsDto.AspNetUserId);

            return productUnitsToDelte;
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
            if (getProductUnitsDto.ProductUnitsId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductUnits).GetProperties()
                    .First(p => p.Name == "ProductUnitsId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductUnitsDto.ProductUnitsId
                });
            }

            if (getProductUnitsDto.Description != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(ProductUnits).GetProperties()
                    .First(p => p.Name == "Description"),
                    Operator = OperationsEnum.Contains,
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

        public async Task<ProductUnits> Update(PutProductUnitsDto putProductUnitsDto)
        {
            ProductUnits productUnitsToUpdate = (from g in _context.Set<ProductUnits>()
                                                where g.ProductUnitsId.Equals(putProductUnitsDto.ProductUnitsId)
                                                select g)
                                               .FirstOrDefault();

            //Abbreviation
            if (putProductUnitsDto.Abbreviation != null)
            {
                productUnitsToUpdate.Abbreviation = putProductUnitsDto.Abbreviation;
            }

            //Description
            if (putProductUnitsDto.Description != null)
            {
                productUnitsToUpdate.Description = putProductUnitsDto.Description;
            }


            EntityEntry entry = _context.Entry(productUnitsToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("ProductUnitsId").IsModified = false;

            _context.Set<ProductUnits>().Update(productUnitsToUpdate);
            _context.SaveChangesAsync(putProductUnitsDto.TableAuditEnum,
                                      putProductUnitsDto.AspNetUserId);

            return productUnitsToUpdate;

        }
    }
}
