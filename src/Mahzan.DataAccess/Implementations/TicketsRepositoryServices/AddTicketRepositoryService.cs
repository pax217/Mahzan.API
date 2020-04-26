using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Interfaces.TicketsRepositoryServices;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Mahzan.DataAccess.Implementations.TicketsRepositoryServices
{
    public class AddTicketRepositoryService : IAddTicketRepositoryService
    {
        private readonly ITicketsRepository _ticketsRepository;

        private readonly ITicketDetailRepository _ticketDetailRepository;

        private readonly ITicketDetailTaxesRepository _ticketDetailTaxesRepository;

        private readonly IProductsStoreRepository _productsStoreRepository;

        public AddTicketRepositoryService(
            ITicketsRepository ticketsRepository,
            ITicketDetailRepository ticketDetailRepository,
            ITicketDetailTaxesRepository ticketDetailTaxesRepository,
            IProductsStoreRepository productsStoreRepository) 
        {
            _ticketsRepository = ticketsRepository;
            _ticketDetailRepository = ticketDetailRepository;
            _ticketDetailTaxesRepository = ticketDetailTaxesRepository;
            _productsStoreRepository = productsStoreRepository;
        }

        public async Task<Tickets> Add(TicketCalculationDto addTicketsDto)
        {
            Tickets newTicket = null;
            TicketDetail newTicketDetail = null;
            TicketDetailTaxes newticketDetailTaxes = null;

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //Ticket
                newTicket = await _ticketsRepository
                                  .Add(addTicketsDto);

                //Ticket Detail
                foreach (var ticketDetail in addTicketsDto.PostTicketCalculationDetailDto)
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

                    await _ticketDetailRepository.AddTicketDetail(newTicketDetail);
                }

                //TicketDetailTaxes
                foreach (var ticketDetailTaxes in addTicketsDto.TicketDetailCalculationTaxesDto)
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

                    await _ticketDetailTaxesRepository.Add(newticketDetailTaxes);
                }

                //ProductsStore
                foreach (var ticketDetail in addTicketsDto.PostTicketCalculationDetailDto)
                {
                    if (ticketDetail.FollowInventory)
                    {

                        Products_Store product_Store = await _productsStoreRepository
                                                             .Get(ticketDetail.ProductsId,
                                                                  addTicketsDto.StoresId);


                        product_Store.InStock--;


                        await _productsStoreRepository
                              .Update(new PutProductsStoreDto { 
                              ProductsStoreId = product_Store.ProductsStoreId,
                              InStock = product_Store.InStock
                              });
                    }
                }


                scope.Complete();
            }

            return newTicket;
        }
    }
}
