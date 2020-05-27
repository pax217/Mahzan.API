using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Products.CreateProduct
{
    public class CreateProductTaxesDto
    {
        public decimal TaxRate { get; set; }
        public Guid TaxesId { get; set; }
    }
}
