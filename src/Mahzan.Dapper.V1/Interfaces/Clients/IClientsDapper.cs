using Mahzan.Dapper.V1.DTO.Clients;
using Mahzan.Dapper.V1.Filters.Clients;
using Mahzan.Dapper.V1.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.V1.Interfaces.Clients
{
    public interface IClientsDapper
    {
        Task<Guid> InsertAsync(InsertClientDto insertClientDto);

        Task<PagedList<Models.Entities.Clients>> GetAsync(GetClientsDto getClientsDto);

        Task<Models.Entities.Clients> GetById(Guid clientsId);

        Task UpdateAsync(UpdateClientDto updateClientDto);

        Task DeleteAsync(Guid clientsId);
    }
}
