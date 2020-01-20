using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.ProductUnits
{
    public class PostProductUnitsRequest
    {
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
