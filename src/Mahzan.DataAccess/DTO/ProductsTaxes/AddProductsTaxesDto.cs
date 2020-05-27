using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductsTaxes
{
    public class AddProductsTaxesDto:BaseDto
    {
        public Guid ProductsId { get; set; }

        public decimal TaxRate { get; set; }

        public Guid TaxesId { get; set; }
    }
}
