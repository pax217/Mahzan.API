using System;
using AutoMapper;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Filters.Products;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;

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

        public PagedList<Products> Get(GetProductsFilter getProductsFilter)
        {
            throw new NotImplementedException();
        }

        public Products Update(PutProductsDto putProductsDto)
        {
            throw new NotImplementedException();
        }
    }
}
