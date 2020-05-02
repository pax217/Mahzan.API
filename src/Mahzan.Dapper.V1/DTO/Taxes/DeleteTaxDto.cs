using Mahzan.Dapper.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Taxes
{
    public class DeleteTaxDto:BaseDto
    {
        public Guid TaxesId { get; set; }
    }
}
