using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Stores
{
    public class AddStoresRequest
    {
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }
        [Required]
        public Guid CompaniesId { get; set; }
    }
}
