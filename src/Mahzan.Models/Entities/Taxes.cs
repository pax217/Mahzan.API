﻿using System;
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

        public decimal TaxRate { get; set; }

        public TaxTypeEnum TaxType { get; set; }
    }
}
