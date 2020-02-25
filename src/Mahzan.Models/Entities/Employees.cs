using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeesId { get; set; }

        public string CodeEmploye { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public Guid MembersId { get; set; }
    }
}
