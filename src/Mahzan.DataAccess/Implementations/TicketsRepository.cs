using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;
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
                ClientsId = addTicketsDto.ClientsId,
                MembersId = addTicketsDto.MembersId
            };

            _context.Set<Tickets>().Add(newTicket);
            await _context.SaveChangesAsync();

            return newTicket;

        }

        public async Task<Tickets> Get(GetTicketDto getTicketDto)
        {
            Tickets result = await (_context.Set<Tickets>()
                                    .Where(x => x.TicketsId== getTicketDto.ticketsId)
                                    .Include(dt => dt.TicketDetails)
                                    .Include(dtt => dtt.TicketDetailTaxes)
                                   ).FirstOrDefaultAsync();

            return result;
        }

        public async Task<PagedList<Tickets>> GetAll(GetTicketsDto getTicketsDto)
        {
            List<Tickets> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getTicketsDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Tickets).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getTicketsDto.MembersId
                });
            }

            if (getTicketsDto.TicketsId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Tickets).GetProperties().First(p => p.Name == "TicketsId"),
                    Operator = OperationsEnum.Equals,
                    Value = getTicketsDto.TicketsId
                });
            }


            /*Los Filtros de Fechas se manejan despues de aplicar el delegado*/

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder
                            .GetExpression<Tickets>(filterExpressions)
                            .Compile();

                result = _context
                         .Set<Tickets>()
                         .Where(deleg)
                         .OrderByDescending(x => x.CreatedAt)
                         .ToList();

                //Filtros de Fecha
                if (getTicketsDto.CreatedAt != null)
                {
                    result = (from ca in result
                              where ca.CreatedAt.Date == getTicketsDto.CreatedAt.Value.Date
                              select ca)
                             .ToList();
                }
            }
            else
            {
                result = _context.Set<Tickets>().ToList();
            }

            return await Task
                         .Run(
                            () => PagedList<Tickets>
                                  .ToPagedList(result,
                                               getTicketsDto.PageNumber,
                                               getTicketsDto.PageSize));
        }
    }
}
