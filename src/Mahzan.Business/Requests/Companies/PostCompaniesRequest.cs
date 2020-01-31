using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Companies
{
    public class PostCompaniesRequest
    {
        [Required]
        [MaxLength(13)]
        public string RFC { get; set; }

        public string CommercialName { get; set; }

        public string BusinessName { get; set; }
        
        [Required]
        public Guid GroupsId { get; set; }
    }
}
