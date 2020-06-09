using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.Exceptions.AspNetRoles.GetAspNetRoles
{
    public class GetAspNetRolesKeyNotFoundException : KeyNotFoundException
    {
        public GetAspNetRolesKeyNotFoundException(string message) : base(message)
        {
        }
    }
}
