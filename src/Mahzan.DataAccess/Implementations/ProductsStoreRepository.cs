using System;
using AutoMapper;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task<Products_Store> Get(Guid productsStoreId, 
                                              Guid storesId)
        {
            Products_Store product_Store = await (from ps in _context.Set<Products_Store>()
                                            where ps.ProductsId == productsStoreId
                                            && ps.StoresId == storesId
                                            select ps)
                                           .FirstOrDefaultAsync();

            return product_Store;
        }

        public async Task<Products_Store> Update(PutProductsStoreDto putProductsStoreDto)
        {
            Products_Store productsStoreToUpdate = await (from g in _context.Set<Products_Store>()
                                                    where g.ProductsStoreId.Equals(putProductsStoreDto.ProductsStoreId)
                                                    select g)
                                                   .FirstOrDefaultAsync();

            //InStock
            if (putProductsStoreDto.InStock!=null)
            {
                productsStoreToUpdate.InStock = putProductsStoreDto.InStock;
            }

            EntityEntry entry = _context.Entry(productsStoreToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("Id").IsModified = false;

            _context.Set<Products_Store>().Update(productsStoreToUpdate);
            await _context.SaveChangesAsync();

            return productsStoreToUpdate;
        }

     
    }
}
