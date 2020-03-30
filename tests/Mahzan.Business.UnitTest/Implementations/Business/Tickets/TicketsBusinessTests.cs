using System;
using System.Threading.Tasks;
using Mahzan.Business.Implementations.Business.Tickets;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Factories.Implemantations.Business.Tickets;
using Moq;
using Xunit;

namespace Mahzan.Business.UnitTest.Implementations.Business.Tickets
{
    public class TicketsBusinessTests
    {


        public TicketsBusinessTests()
        {
        }

        [Fact]
        public async Task Add_New_Ticket()
        {
            //AddTicketsDto addTicketsDto = AddNewTicketFactory.GetAddTicketsDtoValid();

            //Mock<ITicketsRepositories> mockITicketsRepositories = AddNewTicketFactory
            //                                                      .CreateMockITicketsRepositories(addTicketsDto);


            //TicketsBusiness ticketsBusiness = new TicketsBusiness(mockITicketsRepositories.Object);

            //PostTicketsResult result = await ticketsBusiness.Add(addTicketsDto);

            //Assert.NotNull(result);
            //Assert.True(result.IsValid);
            //Assert.NotNull(result.Ticket);
            //Assert.NotNull(result.TicketDetail);
        }
    }
}
