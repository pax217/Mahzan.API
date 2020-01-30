using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class ProductsTaxes
    {
        public Guid ProductsTaxesId { get; set; }

        public Guid ProductsId { get; set; }

        public Guid MembersId { get; set; }

        //Taxes
        public Guid TaxesId { get; set; }
        public Taxes Taxes { get; set; }
    }
}
