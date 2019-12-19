using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.AspNetUsers
{
    public class LogInResult:Result
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
