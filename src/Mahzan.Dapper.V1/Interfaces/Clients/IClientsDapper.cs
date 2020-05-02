using Mahzan.Dapper.DTO.Clients;
using Mahzan.Dapper.Filters.Clients;
using Mahzan.Dapper.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Interfaces.Clients
{
    public interface IClientsDapper
    {
        Task<Guid> InsertAsync(InsertClientDto insertClientDto);

        Task<PagedList<Models.Entities.Clients>> GetWhereAsync(GetClientsDto getClientsDto);

        Task<Models.Entities.Clients> GetById(Guid clientsId);

        Task UpdateAsync(UpdateClientDto updateClientDto);

        Task DeleteAsync(Guid clientsId);
    }
}
