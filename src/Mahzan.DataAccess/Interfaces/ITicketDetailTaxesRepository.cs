using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketDetailTaxesRepository
    {
        Task<TicketDetailTaxes> Add(TicketDetailTaxes ticketDetailTaxes);
    }
}
