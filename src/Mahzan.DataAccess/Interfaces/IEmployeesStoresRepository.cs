using System;
using Mahzan.DataAccess.Filters.EmployeesStores;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IEmployeesStoresRepository: IRepositoryBase<Employees_Stores>
    {
        PagedList<Employees_Stores> Get(GetEmployeesStoresFilter getEmployeesStoresFilter);
    }
}
