using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class PaymentTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentTypesId { get; set; }

        public string Name { get; set; }

        public Guid MembersId { get; set; }
        public Members Members { get; set; }
    }
}
