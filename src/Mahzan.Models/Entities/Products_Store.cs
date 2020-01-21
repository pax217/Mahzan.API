using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Products_Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public decimal InStock { get; set; }

        public decimal LowStock { get; set; }

        public decimal OptimumStock { get; set; }

        //Products
        public Guid ProductsId { get; set; }
        public Products Products { get; set; }

        //Stores
        public Guid StoresId { get; set; }
        public Stores Stores { get; set; }
    }
}
