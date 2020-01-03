using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Companies
{
    public class PostCompaniesRequest
    {
        [Required]
        public string RFC { get; set; }

        public string CommercialName { get; set; }

        public string BusinessName { get; set; }

        public bool Active { get; set; }
        [Required]
        public Guid GroupId { get; set; }
    }
}
