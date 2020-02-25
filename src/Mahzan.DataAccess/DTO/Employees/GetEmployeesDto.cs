using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Employees
{
    public class GetEmployeesDto:BaseDto
    {
        public Guid? EmployeesId { get; set; }
    }
}
