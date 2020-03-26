using Mahzan.Business.Interfaces.Validations.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Validations.Tickets
{
    public class AddTicketsValidations : IAddTicketsValidations
    {
        public Task<PostTicketsResult> AddTicketValid(AddTicketsDto addTicketsDto)
        {
            //Todo: Valida StoreId

            //Todo: Valida PaymentTypesId

            //Todo: Valida PointsOfSalesId

            //Todo: Valida PostTicketDetailDto que todos los productos existan
            throw new NotImplementedException();
        }
    }
}
