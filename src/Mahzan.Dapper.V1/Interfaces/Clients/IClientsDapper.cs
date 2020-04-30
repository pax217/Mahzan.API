using Mahzan.Dapper.V1.DTO.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.V1.Interfaces.Clients
{
    public interface IClientsDapper
    {
        Task<Guid> InsertAsync(InsertClientDto insertClientDto);
    }
}
