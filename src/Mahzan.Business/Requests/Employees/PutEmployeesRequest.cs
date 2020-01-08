using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Employees
{
    public class PutEmployeesRequest
    {
        [Required]
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
