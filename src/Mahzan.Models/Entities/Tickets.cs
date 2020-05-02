﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Tickets
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TicketsId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public decimal Total { get; set; }

        public decimal? CashPayment { get; set; }

        public decimal? CashExchange { get; set; }

        [Required]
        public int TotalProducts { get; set; }

        public string BarCode { get; set; }

        [Required]
        public Guid AspNetUsersId { get; set; }

        [Required]
        public bool Active { get; set; }
        #endregion

        #region Relations

        public Guid PointsOfSalesId { get; set; }
        public PointsOfSales PointsOfSales { get; set; }


        public Guid PaymentTypesId { get; set; }
        public PaymentTypes PaymentTypes { get; set; }

        //Members
        public Guid? ClientsId { get; set; }

        public Guid MembersId { get; set; }

        public List<TicketDetail> TicketDetails { get; set; }

        public List<TicketDetailTaxes> TicketDetailTaxes { get; set; }

        #endregion
    }
}
