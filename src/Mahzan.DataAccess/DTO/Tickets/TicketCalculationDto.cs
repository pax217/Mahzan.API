﻿using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Tickets
{
    public class TicketCalculationDto:BaseDto
    {
        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        public decimal? CashPayment { get; set; }

        public decimal? CashExchange { get; set; }

        public int TotalProducts { get; set; }

        public string BarCode { get; set; }

        public Guid StoresId { get; set; }

        public Guid PointsOfSalesId { get; set; }

        public Guid PaymentTypesId { get; set; }

        public Guid? ClientsId { get; set; }

        public List<PostTicketCalculationDetailDto> PostTicketCalculationDetailDto { get; set; }

        public List<TicketDetailCalculationTaxesDto> TicketDetailCalculationTaxesDto { get; set; }
    }

    public class PostTicketCalculationDetailDto
    {
        public Guid ProductsId { get; set; }

        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public bool FollowInventory { get; set; }
    }

    public class TicketDetailCalculationTaxesDto 
    {
        public decimal TaxRate { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public Guid ProductsId { get; set; }
        public Guid TaxesId { get; set; }
    }
}
