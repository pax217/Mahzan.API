using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductUnits;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductUnitsRepository:IRepositoryBase<ProductUnits>
    {
        Task<ProductUnits> Add(AddProductUnitsDto addProductUnitsDto);
    }
}
