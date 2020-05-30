using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Company_Contact
    {
        public Guid CompanyContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Facebook { get; set; }
        public string Phone { get; set; }
        public Guid CompaniesId { get; set; }
    }
}
