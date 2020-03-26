using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class TicketsRepository: RepositoryBase<Tickets>, ITicketsRepository
    {
        readonly IMapper _mapper;

        public TicketsRepository(
            MahzanDbContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {

            _mapper = mapper;
        }

        public async Task<Tickets> Add(AddTicketsDto addTicketsDto)
        {
            Tickets newTicket = null;
            TicketDetail newTicketDetail = null;
            TicketDetailTaxes newticketDetailTaxes = null;

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //Ticket
                newTicket = new Tickets
                {
                    CreatedAt = DateTime.Now,
                    Total = addTicketsDto.Total,
                    TotalProducts = addTicketsDto.TotalProducts,
                    BarCode = addTicketsDto.BarCode,
                    Active = true,
                    PointsOfSalesId = addTicketsDto.PointsOfSalesId,
                    PaymentTypesId = addTicketsDto.PaymentTypesId,
                    AspNetUsersId = addTicketsDto.AspNetUserId,
                    
                };

                _context.Set<Tickets>().Add(newTicket);


                //TicketDetail

                foreach (var ticketDetail in addTicketsDto.PostTicketDetailDto)
                {
                    newTicketDetail = new TicketDetail
                    {
                        ProductsId = ticketDetail.ProductsId,
                        Quantity = ticketDetail.Quantity,
                        Description = ticketDetail.Description,
                        Price = ticketDetail.Price,
                        Amount = ticketDetail.Amount,
                        TicketsId = newTicket.TicketsId
                    };

                    _context.Set<TicketDetail>().Add(newTicketDetail);
                }

                //TicketDetailTaxes
                foreach (var ticketDetailTaxes in addTicketsDto.TicketDetailTaxesDto)
                {
                    newticketDetailTaxes = new TicketDetailTaxes
                    {
                        TaxRate = ticketDetailTaxes.TaxRate,
                        Price = ticketDetailTaxes.Price,
                        Amount = ticketDetailTaxes.Amount,
                        ProductsId = ticketDetailTaxes.ProductsId,
                        TaxesId = ticketDetailTaxes.TaxesId,
                        TicketsId = newTicket.TicketsId
                    };

                    _context.Set<TicketDetailTaxes>().Add(newticketDetailTaxes);
                }


                await _context.SaveChangesAsync();
                scope.Complete();
            }



            return newTicket;

        }
    }
}
