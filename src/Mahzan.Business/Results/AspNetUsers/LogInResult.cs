using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.AspNetUsers
{
    public class LogInResult:Result
    {
        public string Token { get; set; }

        public string Role { get; set; }

        public string AspNetUsersId { get; set; }

        public string UserName { get; set; }

        public Guid? EmployeesId { get; set; }
    }
}
