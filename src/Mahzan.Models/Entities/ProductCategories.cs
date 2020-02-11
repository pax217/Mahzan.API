using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class ProductCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductCategoriesId { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public Guid MembersId { get; set; }
    }
}
