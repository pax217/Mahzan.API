using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.EmployeesStores
{
    public class AddEmployeesStoresDto:BaseDto
    {
        public Guid GroupId { get; set; }
 
        public Guid CompanyId { get; set; }
  
        public Guid StoreId { get; set; }
  
        public Guid EmployeeId { get; set; }

        public bool Active { get; set; }
    }
}
