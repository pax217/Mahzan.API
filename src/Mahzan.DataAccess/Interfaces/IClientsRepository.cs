using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IClientsRepository
    {
        Task<Clients> Add(AddClientsDto addClientsDto);

        PagedList<Clients> Get(GetClientsDto getClientsDto);
    }
}
