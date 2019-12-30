using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Miembros;
using Mahzan.DataAccess.DTO.Miembros;

namespace Mahzan.Business.Interfaces.Validations.Miembros
{
    public interface IAddMiembrosValidations
    {
        Task<AddMiembroResult> AddMiembroValid(AddMiembrosDto addMiembrosDto);
    }
}
