using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Products.CreateProduct
{
    public class CreateProductTaxesEvent
    {
        public decimal TaxRate { get; set; }
        public Guid TaxesId { get; set; }
    }
}
