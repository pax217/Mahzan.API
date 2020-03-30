using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.EmployeesStores
{
    public class GetEmployeesStoresDto:BaseDto
    {
        public Guid? EmployeesId { get; set; }
    }
}
