using System;
using Mahzan.Business.Enums.AspNetRoles;

namespace Mahzan.Business.Requests.Employees
{
    public class PostEmployeesRequest
    {
        public string CodeEmploye { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleEnum Role { get; set; }
    }
}
