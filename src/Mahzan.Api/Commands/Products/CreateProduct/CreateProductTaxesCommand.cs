using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Products.CreateProduct
{
    public class CreateProductTaxesCommand
    {
        public decimal TaxRate { get; set; }
        public Guid TaxesId { get; set; }
    }
}
