using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.Models.Entities
{
    public class Taxes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaxesId { get; set; }

        public string Name { get; set; }

        public decimal TaxRateVariable { get; set; }

        public decimal TaxRatePercentage { get; set; }

        public bool Active { get; set; }

        public bool Printed { get; set; }

        public Guid MembersId { get; set; }
    }
}
