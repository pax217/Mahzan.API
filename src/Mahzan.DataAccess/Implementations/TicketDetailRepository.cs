using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class TicketDetailRepository: RepositoryBase<TicketDetail>, ITicketDetailRepository
    {
        public TicketDetailRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<List<TicketDetail>> Add(Tickets newTicket,
                                                  List<PostTicketCalculationDetailDto> postTicketDetailDto)
        {
            List<TicketDetail> result = new List<TicketDetail> { };


            foreach (var ticketDetail in postTicketDetailDto)
            {
                TicketDetail newTicketDetail = new TicketDetail
                {
                    ProductsId = ticketDetail.ProductsId,
                    Quantity = ticketDetail.Quantity,
                    //Description = ticketDetail.Description,
                    //Price = ticketDetail.Price,
                    //Amount = ticketDetail.Amount,
                    TicketsId = newTicket.TicketsId
                };

                _context.Set<TicketDetail>().Add(newTicketDetail);

                await _context.SaveChangesAsync();

                result.Add(newTicketDetail);
            }

            return result;
        }
    }
}
