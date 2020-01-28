using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Companies
{
    public class AddCompaniesResult:Result
    {
        public Models.Entities.Companies Company { get; set; }
    }
}
