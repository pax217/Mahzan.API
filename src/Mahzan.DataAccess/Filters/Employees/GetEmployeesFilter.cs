using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Employees
{
    public class GetEmployeesFilter: FilterBase
    {
        public Guid? EmployeId { get; set; }
        public Guid? MemberId { get; set; }
    }
}
