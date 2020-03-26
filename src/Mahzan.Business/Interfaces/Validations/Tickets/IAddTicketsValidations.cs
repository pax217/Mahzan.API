using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Validations.Tickets
{
    public interface IAddTicketsValidations
    {
        Task<PostTicketsResult> AddTicketValid(AddTicketsDto addTicketsDto);

    }
}
