using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Employees
{
    public class PutEmployeesDto:BaseDto
    {
        public Guid EmployeeId { get; set; }

        public string CodeEmploye { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool? Active { get; set; }
    }
}
