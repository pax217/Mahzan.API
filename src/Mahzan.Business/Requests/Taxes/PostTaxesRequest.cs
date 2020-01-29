using System;
using System.Collections.Generic;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.Business.Requests.Taxes
{
    public class PostTaxesRequest
    {
        public string Name { get; set; }

        public decimal TaxRate { get; set; }

        public TaxTypeEnum TaxType { get; set; }

        public TaxOptionsEnum TaxOption { get; set; }

        public List<Guid> StoresIds { get; set; }
    }
}
