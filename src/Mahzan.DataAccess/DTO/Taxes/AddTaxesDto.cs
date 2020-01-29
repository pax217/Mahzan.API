using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.DataAccess.DTO.Taxes
{
    public class AddTaxesDto:BaseDto
    {
        public string Name { get; set; }

        public decimal TaxRate { get; set; }

        public TaxTypeEnum TaxType { get; set; }

        public TaxOptionsEnum TaxOption { get; set; }

        public List<Guid> StoresIds { get; set; }
    }
}
