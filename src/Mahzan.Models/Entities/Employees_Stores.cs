using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Employees_Stores
    {
        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeesStoresId { get; set; }

        public Guid GroupId { get; set; }

        public Guid CompaniesId { get; set; }

        public Guid StoresId { get; set; }

        public Guid MembersId { get; set; }

        #endregion

        #region Relations

        public Guid EmployeesId { get; set; }
        public Employees Employees { get; set; }

        #endregion

    }
}
