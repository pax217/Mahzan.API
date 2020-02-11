using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class ProductUnits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductUnitsId { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }

        public Guid MembersId { get; set; }

    }
}
