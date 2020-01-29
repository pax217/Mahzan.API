using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Taxes_Stores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaxesStoresId { get; set; }

        public Guid StoresId { get; set; }

        public Guid MembersId { get; set; }

        //Taxes
        public Guid TaxesId { get; set; }
        public Taxes Taxes { get; set; }
    }
}
