using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductUnits;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductUnitsRepository:IRepositoryBase<ProductUnits>
    {
        Task<ProductUnits> Add(AddProductUnitsDto addProductUnitsDto);

        PagedList<ProductUnits> Get(GetProductUnitsDto getProductUnitsDto);

        Task<ProductUnits> Delete(DeleteProductUnitsDto deleteProductUnitsDto);

        Task<ProductUnits> Update(PutProductUnitsDto putProductUnitsDto);
    }
}
