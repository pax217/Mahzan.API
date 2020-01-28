using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Stores;
using Mahzan.DataAccess.DTO.Stores;

namespace Mahzan.Business.Interfaces.Validations.Stores
{
    public interface IAddStoresValidations
    {
        Task<AddStoresResult> AddStoresValid(AddStoresDto addStoresDto);
    }
}
