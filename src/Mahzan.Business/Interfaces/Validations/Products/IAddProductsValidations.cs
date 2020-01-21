using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;

namespace Mahzan.Business.Interfaces.Validations.Products
{
    public interface IAddProductsValidations
    {
        Task<PostProductsResult> AddProductsValid(AddProductsDto addProductsDto);
    }
}
