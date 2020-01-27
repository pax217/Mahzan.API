using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;

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

        public Products Add(AddProductsDto addProductsDto)
        {
            Products newProduct = null;

            newProduct = _mapper.Map<Products>(addProductsDto);


            _context.Set<Products>().Add(newProduct);
            _context.SaveChanges();

            return newProduct;
        }

        public Products Delete(DeleteProductsDto deleteProductsDto)
        {
            throw new NotImplementedException();
        }

        public PagedList<Products> Get(GetProductsDto getProductsDto)
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

                result = _context.Set<Products>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Products>().ToList();
            }

            return PagedList<Products>.ToPagedList(result,
                                                 getProductsDto.PageNumber,
                                                 getProductsDto.PageSize);

        }

        public Products Update(PutProductsDto putProductsDto)
        {
            throw new NotImplementedException();
        }
    }
}
