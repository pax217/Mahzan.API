using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Employees
{
    public class DeleteEmployeesResult:Result
    {
        public Models.Entities.Employees Employee { get; set; }
    }
}
