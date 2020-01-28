using System;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Filters.Stores;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IStoresRepository: IRepositoryBase<Stores>
    {
        Stores Add(AddStoresDto addStoresDto);

        PagedList<Stores> Get(GetStoresDto getStoresDto);

        Stores Update(PutStoresDto putStoresDto);

        Stores Delete(DeleteStoresDto deleteStoresDto);
    }
}
