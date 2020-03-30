using Mahzan.Business.Interfaces.Validations.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Business.Tickets
{
    public interface ITicketsValidations
    {
        Task<PostTicketsResult> AddTicketValid(AddTicketsDto addTicketsDto);
    }
}
