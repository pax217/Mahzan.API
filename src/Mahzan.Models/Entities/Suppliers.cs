using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Suppliers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SuppliersId { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Notes { get; set; }
    }
}
