using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.EmployeesStores;
using Mahzan.DataAccess.DTO.EmployeesStores;
using Mahzan.DataAccess.Filters.EmployeesStores;

namespace Mahzan.Business.Interfaces.Business.EmployeesStores
{
    public interface IEmployeesStoresBusiness
    {
        Task<PostEmployeesStoresResult> Add(AddEmployeesStoresDto addEmployeesStoresDto);

        Task<GetEmployeesStoresResult> Get(GetEmployeesStoresDto getEmployeesStoresDto);
    }
}
