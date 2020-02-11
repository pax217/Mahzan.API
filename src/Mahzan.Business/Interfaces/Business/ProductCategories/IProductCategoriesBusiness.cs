using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.ProductCategories;
using Mahzan.DataAccess.DTO.ProductCategories;

namespace Mahzan.Business.Interfaces.Business.ProductCategories
{
    public interface IProductCategoriesBusiness
    {
        Task<PostProductCategoriesResult> Add(AddProductCategoriesDto addProductCategoriesDto);

        Task<GetProductCategoriesResult> Get(GetProductsCategoriesDto getProductsCategoriesDto);
    }
}
