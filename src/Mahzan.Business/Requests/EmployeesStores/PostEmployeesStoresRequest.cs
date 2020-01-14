using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.EmployeesStores
{
    public class PostEmployeesStoresRequest
    {
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public Guid StoreId { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public bool Active { get; set; }
    }
}
