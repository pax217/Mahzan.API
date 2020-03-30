using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Interfaces.Validations.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Business.Tickets
{
    public class TicketsValidations : ITicketsValidations
    {
        public IAddTicketsValidations _addTicketsValidations { get; set; }

        public TicketsValidations(
            IAddTicketsValidations ticketsValidations)
        {
            _addTicketsValidations = ticketsValidations;
        }

        public async Task<PostTicketsResult> AddTicketValid(AddTicketsDto addTicketsDto)
        {
            return await _addTicketsValidations
                         .AddTicketValid(addTicketsDto);
        }
    }
}
