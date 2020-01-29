using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductsTaxes
{
    public class ProductsTaxesDto:BaseDto
    {
        public Guid ProductsId { get; set; }

        public Guid TaxesId { get; set; }
    }
}
