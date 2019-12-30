using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Miembros;
using Mahzan.DataAccess.DTO.Miembros;

namespace Mahzan.Business.Interfaces.Business
{
    public interface IMiembrosBusiness
    {
        Task<AddMiembroResult> Add(AddMiembrosDto addMiembrosDto);
        Guid Get(string userName);
    }
}
