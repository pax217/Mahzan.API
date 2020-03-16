using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductsTaxesRepository:IRepositoryBase<ProductsTaxes>
    {
        Task<ProductsTaxes> Add(AddProductsTaxesDto productsTaxesDto);

        Task<PagedList<ProductsTaxes>> Get(GetProductsTaxesDto getProductsTaxesDto);
    }
}
