using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Clients;
using Mahzan.DataAccess.DTO.Clients;

namespace Mahzan.Business.Interfaces.Validations.Clients
{
    public interface IAddClientsValidations
    {
        Task<PostClientsResult> AddClientsValid(AddClientsDto addClientsDto);
    }
}
