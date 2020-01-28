using System;
using System.Threading.Tasks;
using Mahzan.Business.Requests.Stores;
using Mahzan.Business.Results.Stores;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Filters.Stores;

namespace Mahzan.Business.Interfaces.Business.Stores
{
    public interface IStoresBusiness
    {
        Task<AddStoresResult> Add(AddStoresDto addStoresDto);

        Task<GetStoresResult> Get(GetStoresDto getStoresDto);

        Task<PutStoresResult> Update(PutStoresDto putStoresDto);

        Task<DeleteStoresResult> Delete(DeleteStoresDto deleteStoresDto);
    }
}
