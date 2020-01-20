using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;

namespace Mahzan.Business.Interfaces.Validations.Groups
{
    public interface IAddGroupsValidations
    {
        Task<AddGroupsResult> AddGroupsValid(AddGroupsDto addGroupsDto);
    }
}
