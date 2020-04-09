using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<Tickets> Add(TicketCalculationDto addTicketsDto)
        {
            Tickets newTicket = null;

            //Ticket
            newTicket = new Tickets
            {
                CreatedAt = DateTime.Now,
                Total = addTicketsDto.Total,
                CashPayment = addTicketsDto.CashPayment,
                CashExchange = addTicketsDto.CashExchange,
                TotalProducts = addTicketsDto.TotalProducts,
                BarCode = addTicketsDto.BarCode,
                Active = true,
                PointsOfSalesId = addTicketsDto.PointsOfSalesId,
                PaymentTypesId = addTicketsDto.PaymentTypesId,
                AspNetUsersId = addTicketsDto.AspNetUserId,

            };

            _context.Set<Tickets>().Add(newTicket);
            await _context.SaveChangesAsync();

            //Tickets newTicket = null;
            //TicketDetail newTicketDetail = null;
            //TicketDetailTaxes newticketDetailTaxes = null;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
            //    //Ticket
            //    newTicket = new Tickets
            //    {
            //        CreatedAt = DateTime.Now,
            //        Total = addTicketsDto.Total,
            //        CashPayment = addTicketsDto.CashPayment,
            //        CashExchange = addTicketsDto.CashExchange,
            //        TotalProducts = addTicketsDto.TotalProducts,
            //        BarCode = addTicketsDto.BarCode,
            //        Active = true,
            //        PointsOfSalesId = addTicketsDto.PointsOfSalesId,
            //        PaymentTypesId = addTicketsDto.PaymentTypesId,
            //        AspNetUsersId = addTicketsDto.AspNetUserId,

            //    };

            //    _context.Set<Tickets>().Add(newTicket);


            //    //TicketDetail

            //    foreach (var ticketDetail in addTicketsDto.PostTicketCalculationDetailDto)
            //    {
            //        newTicketDetail = new TicketDetail
            //        {
            //            ProductsId = ticketDetail.ProductsId,
            //            Quantity = ticketDetail.Quantity,
            //            Description = ticketDetail.Description,
            //            Price = ticketDetail.Price,
            //            Amount = ticketDetail.Amount,
            //            TicketsId = newTicket.TicketsId
            //        };

            //        _context.Set<TicketDetail>().Add(newTicketDetail);
            //    }

            //    //TicketDetailTaxes
            //    foreach (var ticketDetailTaxes in addTicketsDto.TicketDetailCalculationTaxesDto)
            //    {
            //        newticketDetailTaxes = new TicketDetailTaxes
            //        {
            //            TaxRate = ticketDetailTaxes.TaxRate,
            //            Price = ticketDetailTaxes.Price,
            //            Amount = ticketDetailTaxes.Amount,
            //            ProductsId = ticketDetailTaxes.ProductsId,
            //            TaxesId = ticketDetailTaxes.TaxesId,
            //            TicketsId = newTicket.TicketsId
            //        };

            //        _context.Set<TicketDetailTaxes>().Add(newticketDetailTaxes);
            //    }

            //    //ProductsStore
            //    foreach (var ticketDetail in addTicketsDto.PostTicketCalculationDetailDto)
            //    {
            //        if (ticketDetail.FollowInventory)
            //        {
            //            Products_Store product_Store = (from ps in _context.Set<Products_Store>()
            //                                            where ps.ProductsId == ticketDetail.ProductsId
            //                                            && ps.StoresId == addTicketsDto.StoresId
            //                                            select ps)
            //                                           .FirstOrDefault();

            //            product_Store.InStock--;

            //            EntityEntry entry = _context.Entry(product_Store);
            //            entry.State = EntityState.Modified;
            //            entry.Property("ProductsStoreId").IsModified = false;

            //            _context.Set<Products_Store>().Update(product_Store);

            //        }
            //    }

            //    await _context.SaveChangesAsync();
            //    scope.Complete();
            //}



            return newTicket;

        }
    }
}
