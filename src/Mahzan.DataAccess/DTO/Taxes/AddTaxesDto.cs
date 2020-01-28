using System;
using Mahzan.DataAccess.DTO._Base;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.DataAccess.DTO.Taxes
{
    public class AddTaxesDto:BaseDto
    {
        public decimal TaxRate { get; set; }

        public TaxTypeEnum TaxType { get; set; }

        public TaxOptionsEnum TaxOption { get; set; }
    }
}
