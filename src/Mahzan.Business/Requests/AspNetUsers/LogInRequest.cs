using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.AspNetUsers
{
    public class LogInRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
