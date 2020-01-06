using System;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Filters.Stores;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IStoresRepository: IRepositoryBase<Stores>
    {
        PagedList<Stores> Get(GetStoresFilter getStoresFilter);

        Stores Update(PutStoresDto putStoresDto);

        Stores Delete(DeleteStoresDto deleteStoresDto);
    }
}
