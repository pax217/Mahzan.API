using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.EmployeesStores;
using Mahzan.DataAccess.Filters.EmployeesStores;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IEmployeesStoresRepository: IRepositoryBase<Employees_Stores>
    {
        Task<PagedList<Employees_Stores>> Get(GetEmployeesStoresDto getEmployeesStoresDto);
    }
}
