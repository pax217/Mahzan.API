using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductsTaxesRepository:IRepositoryBase<ProductsTaxes>
    {
        Task<ProductsTaxes> Add(ProductsTaxesDto productsTaxesDto);
    }
}
