using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.EmployeesStores
{
    public class GetEmployeesStoresFilter:FilterBase
    {
        public Guid EmployeeId { get; set; }
    }
}
