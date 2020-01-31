using System;
using System.Threading.Tasks;
using Mahzan.Business.Requests.Clients;
using Mahzan.Business.Results.Clients;
using Mahzan.DataAccess.DTO.Clients;

namespace Mahzan.Business.Interfaces.Business.Clients
{
    public interface IClientsBusiness
    {
        Task<PostClientsResult> Add(AddClientsDto addClientsDto);

        Task<GetClientsResult> Get(GetClientsDto getClientsDto);

        Task<PutClientsResult> Update(PutClientsDto putClientsDto);

        Task<DeleteClientsResult> Delete(DeleteClientsDto deleteClientsDto);

    }
}
