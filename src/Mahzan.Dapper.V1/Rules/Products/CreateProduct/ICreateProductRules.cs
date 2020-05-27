using Mahzan.Dapper.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Rules.Products.CreateProduct
{
    public interface ICreateProductRules
    {
        Task Handle(CreateProductDto createProductDto);
    }
}
