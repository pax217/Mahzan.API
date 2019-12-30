using System;
using System.Threading.Tasks;
using Mahzan.Business.Interfaces.Validations.Miembros;
using Mahzan.Business.Results.Miembros;
using Mahzan.DataAccess.DTO.Miembros;

namespace Mahzan.Business.Implementations.Validations.Miembros
{
    public class AddMiembrosValidations : IAddMiembrosValidations
    {
        public Task<AddMiembroResult> AddMiembroValid(AddMiembrosDto addMiembrosDto)
        {
            throw new NotImplementedException();
        }
    }
}
