using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Stores
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StoresId { get; set; }
        
        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        //Companies
        public Guid CompaniesId { get; set; }

        //Members
        public Guid MembersId { get; set; }
    }
}
