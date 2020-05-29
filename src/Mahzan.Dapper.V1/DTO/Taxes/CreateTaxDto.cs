using Mahzan.Dapper.DTO._Base;
using Mahzan.Models.Enums.Taxes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Taxes
{
    public class CreateTaxDto:BaseDto
    {
        public string Name { get; set; }

        public TaxTypeEnum Type { get; set; }

        public bool TaxRateVariable { get; set; }

        public decimal TaxRatePercentage { get; set; }

        public bool Active { get; set; }

        public bool Printed { get; set; }
    }
}
