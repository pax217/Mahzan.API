using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Company_Adress
    {
        public Guid CompanyAdressesId { get; set; }
        public string Street { get; set; }
        public string OutdoorNumber { get; set; }
        public string InteriorNumber { get; set; }
        public string Suburb { get; set; }
        public string TownHall { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Guid CompaniesId { get; set; }
    }
}
