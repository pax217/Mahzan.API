using System;
using System.Collections;
using System.Collections.Generic;
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

        public bool FollowInventory { get; set; }

        public bool AvailableInAllStores { get; set; }

        //Members
        public Guid MembersId { get; set; }
        public Members Members { get; set; }

        //Products Categories
        public Guid ProductCategoriesId { get; set; }
        public ProductCategories ProductCategories { get; set; }

        //Products Units
        public Guid ProductUnitsId { get; set; }
        public ProductUnits ProductUnits { get; set; }

    }
}
