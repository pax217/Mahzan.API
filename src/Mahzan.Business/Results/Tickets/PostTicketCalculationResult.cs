using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.DTO.Tickets;
using Newtonsoft.Json;

namespace Mahzan.Business.Results.Tickets
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PostTicketCalculationResult:Result
    {
        public decimal Total { get; set; }

        public int TotalProducts { get; set; }

        public List<PostTicketCalculationDetailDto> PostTicketDetailDto { get; set; }

        public List<TicketDetailCalculationTaxesDto> TicketDetailTaxesDto { get; set; }
    }
}
