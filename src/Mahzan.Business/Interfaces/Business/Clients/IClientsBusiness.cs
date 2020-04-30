using System;
using System.Threading.Tasks;
using Mahzan.Business.Requests.Clients;
using Mahzan.Business.Results.Clients;
using Mahzan.Dapper.V1.DTO.Clients;

namespace Mahzan.Business.Interfaces.Business.Clients
{
    public interface IClientsBusiness
    {
        Task<PostClientsResult> Add(InsertClientDto insertClientDto);

        Task<GetClientsResult> Get(GetClientsDto getClientsDto);

        Task<PutClientsResult> Update(UpdateClientDto updateClientDto);

        Task<DeleteClientsResult> Delete(DeleteClientDto deleteClientsDto);

    }
}
