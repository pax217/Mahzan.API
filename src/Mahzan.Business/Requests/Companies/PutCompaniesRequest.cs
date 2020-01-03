using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Companies
{
    public class PutCompaniesRequest
    {
        [Required]
        public Guid CompanyId { get; set; }
        public string RFC { get; set; }
        public string CommercialName { get; set; }
        public string BusinessName { get; set; }
        public bool? Active { get; set; }
    }
}
