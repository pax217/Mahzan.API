using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Implementations
{
    public class TicketDetailTaxesRepository : RepositoryBase<TicketDetailTaxes>, ITicketDetailTaxesRepository
    {

        public TicketDetailTaxesRepository(
            MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<TicketDetailTaxes> Add(TicketDetailTaxes ticketDetailTaxes)
        {
            _context.Set<TicketDetailTaxes>().Add(ticketDetailTaxes);
            await _context.SaveChangesAsync();

            return ticketDetailTaxes;
        }
    }
}
