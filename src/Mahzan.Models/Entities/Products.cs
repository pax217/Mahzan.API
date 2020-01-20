using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public Guid MemberId { get; set; }

        public ProductCategories ProductCategories { get; set; }

        public ProductUnits ProductUnits { get; set; }

    }
}
