using Mahzan.Business.Results._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.AspNetRoles
{
    public class GetAspNetRolesResult:Result
    {
        public List<Models.Entities.AspNetRoles> AspNetRoles { get; set; }
    }
}
