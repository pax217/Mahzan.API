using System;
using AutoMapper;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class ProductsStoreRepository : RepositoryBase<Products_Store>, IProductsStoreRepository
    {
        readonly IMapper _mapper;

        public ProductsStoreRepository(
            MahzanDbContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }
        public  Products_Store Add(AddProductsStoreDto addProductsStoreDto)
        {
            Products_Store newProductsStore = null;

            newProductsStore = _mapper.Map<Products_Store>(addProductsStoreDto);

            _context.Set<Products_Store>().Add(newProductsStore);
            _context.SaveChanges();

            return newProductsStore;
        }
    }
}
