using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Employees_Stores
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public Guid CompanyId { get; set; }

        public Guid StoreId { get; set; }

        public Guid EmployeeId { get; set; }

        public bool Active { get; set; }

        public Guid MemberId { get; set; }
    }
}
