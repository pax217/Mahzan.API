using System;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Results.Employees
{
    public class GetEmployeesResult:Result
    {
        public PagedList<Models.Entities.Employees> Employees { get; set; }
        public Paging Paging { get; set; }

    }
}
