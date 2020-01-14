using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.EmployeesStores
{
    public class GetEmployeesStoresResult:Result
    {
        public List<Models.Entities.Stores> Stores { get; set; }
    }
}
