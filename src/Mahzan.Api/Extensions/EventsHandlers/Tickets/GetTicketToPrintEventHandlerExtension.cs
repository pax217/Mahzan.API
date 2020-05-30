using Mahzan.Business.EventsHandlers.Tickets.GetTicketToPrint;
using Mahzan.Dapper.Repositories.Companies.GetCompany;
using Mahzan.Dapper.Repositories.Company_Adress.GetCompanyAdress;
using Mahzan.Dapper.Repositories.Company_Contact.GetCompanyContact;
using Mahzan.Dapper.Repositories.TicketDetail.GetTicketDetail;
using Mahzan.Dapper.Repositories.Tickets.GetTicket;
using Mahzan.Dapper.Repositories.Tickets.GetTicketToPrint;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Extensions.EventsHandlers.Tickets
{
    public static class GetTicketToPrintEventHandlerExtension
    {
        public static void Configure(
            IServiceCollection services)
        {
            services
                .AddScoped<IGetTicketToPrintEventHandler>(
                x => new GetTicketToPrintEventHandler(
                    x.GetService<IGetTicketToPrintRepository>(),
                    x.GetService<IGetCompanyRepository>(),
                    x.GetService<IGetCompanyAdressRepository>(),
                    x.GetService<IGetCompanyContactRepository>(),
                    x.GetService<IGetTicketDetailRepository>(),
                    x.GetService<IGetTicketRepository>()
                    )
                );
        }
    }
}
