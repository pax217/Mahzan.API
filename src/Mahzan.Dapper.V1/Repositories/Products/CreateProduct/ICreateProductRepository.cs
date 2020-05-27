using Mahzan.Dapper.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Products.CreateProduct
{
    public interface ICreateProductRepository
    {
        Task Handle(CreateProductDto createProductDto);
    }
}
