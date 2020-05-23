using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.Business.Requests.Taxes
{
    public class PostTaxesRequest
    {
        [Required]
        public string Name { get; set; }
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
