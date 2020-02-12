using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.ProductUnits
{
    public class PutProductUnitsRequest
    {
        [Required]
        public Guid ProductUnitsId { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }
    }
}
