using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Tickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TicketsId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public Guid AspNetUsersId { get; set; }

        //PointsOfSale
        public Guid PointsOfSalesId{ get; set; }

        //PointsOfSale
        public Guid PaymentTypesId { get; set; }

    }
}
