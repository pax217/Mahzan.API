using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.ProductUnits;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.DataAccess.DTO.ProductUnits;

namespace Mahzan.Business.Interfaces.Business.ProductUnits
{
    public interface IProductUnitsBusiness
    {
        Task<PostProductUnitsResult> Add(AddProductUnitsDto addProductUnitsDto);

        Task<GetGetProductUnitsResult> Get(GetProductUnitsDto getProductUnitsDto);
    }
}
