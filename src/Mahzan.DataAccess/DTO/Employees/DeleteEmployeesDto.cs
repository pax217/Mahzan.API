using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Employees
{
    public class DeleteEmployeesDto:BaseDto
    {
        public Guid EmployeeId { get; set; }

    }
}
