using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductsRepository: RepositoryBase<Products>, IProductsRepository
    {
        readonly IMapper _mapper;

        public ProductsRepository(
            MahzanDbContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public async Task<Products> Add(AddProductsDto addProductsDto)
        {
            Products newProduct = new Products {
                ProductCategoriesId  = addProductsDto.AddProductDetailDto.ProductCategoriesId,
                ProductUnitsId = addProductsDto.AddProductDetailDto.ProductUnitsId,
                SKU = addProductsDto.AddProductDetailDto.SKU,
                Barcode = addProductsDto.AddProductDetailDto.Barcode,
                Description = addProductsDto.AddProductDetailDto.Description,
                Price = addProductsDto.AddProductDetailDto.Price,
                Cost = addProductsDto.AddProductDetailDto.Cost,
                MembersId = addProductsDto.MembersId
            };

            _context.Set<Products>().Add(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;
        }

        public async Task<Products> Delete(DeleteProductsDto deleteProductsDto)
        {
            Products productToDelte = (from g in _context.Set<Products>()
                                   where g.ProductsId.Equals(deleteProductsDto.ProductsId)
                                   select g)
                                    .FirstOrDefault();

            _context.Set<Products>().Remove(productToDelte);
            await _context.SaveChangesAsync(deleteProductsDto.TableAuditEnum,
                                      deleteProductsDto.AspNetUserId);

            return productToDelte;
        }

        public async Task<PagedList<Products>> Get(GetProductsDto getProductsDto)
        {
            List<Products> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getProductsDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Products).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsDto.MembersId
                });
            }

            if (getProductsDto.ProductsId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Products).GetProperties().First(p => p.Name == "ProductsId"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsDto.ProductsId
                });
            }

            if (getProductsDto.Barcode != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Products).GetProperties().First(p => p.Name == "Barcode"),
                    Operator = OperationsEnum.Equals,
                    Value = getProductsDto.Barcode
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Products>(filterExpressions).Compile();

                result = _context.Set<Products>()
                                 .Include(pp => pp.ProductsPhotos)
                                 .Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Products>()
                                 .Include(pp => pp.ProductsPhotos)
                                 .ToList();
            }

            return await Task.Run(() => PagedList<Products>
                                        .ToPagedList(result,
                                                     getProductsDto.PageNumber,
                                                     getProductsDto.PageSize));

        }

        public Task<Products> Update(PutProductsDto putProductsDto)
        {
            throw new NotImplementedException();
        }
    }
}
