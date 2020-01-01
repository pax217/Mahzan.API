using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Members;
using Mahzan.DataAccess.DTO.Miembros;

namespace Mahzan.Business.Interfaces.Validations.Miembros
{
    public interface IAddMembersValidations
    {
        Task<AddMembersResult> AddMembersValid(AddMiembrosDto addMiembrosDto);
    }
}
