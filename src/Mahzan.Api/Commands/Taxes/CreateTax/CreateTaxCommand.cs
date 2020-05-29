using Mahzan.Models.Enums.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Taxes.CreateTax
{
    public class CreateTaxCommand
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TaxTypeEnum Type { get; set; }
        [Required]
        public bool TaxRateVariable { get; set; }
        [Required]
        public decimal TaxRatePercentage { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool Printed { get; set; }
    }
}
