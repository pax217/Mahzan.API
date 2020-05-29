using Mahzan.Business.Events._Base;
using Mahzan.Models.Enums.Taxes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Taxes.CreateTax
{
    public class CreateTaxEvent:BaseEvent
    {
        public string Name { get; set; }

        public TaxTypeEnum Type { get; set; }

        public bool TaxRateVariable { get; set; }

        public decimal TaxRatePercentage { get; set; }

        public bool Active { get; set; }

        public bool Printed { get; set; }
    }
}
