using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class TicketDetailTaxes
    {

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TicketDetailTaxesId { get; set; }

        public decimal TaxRate { get; set; }

        public decimal Amount { get; set; }

        #endregion

        #region Relations

        public Guid ProductsId { get; set; }

        public Guid TaxesId { get; set; }

        public Guid TicketsId { get; set; }
        public Tickets Tickets { get; set; }
        #endregion
    }
}
