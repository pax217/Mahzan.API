using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.DataAccess.DTO.PaymentTypes;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;

namespace Mahzan.DataAccess.Implementations
{
    public class PaymentTypesRepository: RepositoryBase<PaymentTypes>, IPaymentTypesRepository
    {
        readonly IMapper _mapper;

        public PaymentTypesRepository(
            MahzanDbContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public async Task<PaymentTypes> Add(AddPaymentTypesDto addPaymentTypesDto)
        {
            PaymentTypes newPaymentTypes = new PaymentTypes {
                Name = addPaymentTypesDto.Name,
                MembersId = addPaymentTypesDto.MembersId
            };

            _context.Set<PaymentTypes>().Add(newPaymentTypes);

            await _context.SaveChangesAsync();

            return newPaymentTypes;
        }

        public async Task<PagedList<PaymentTypes>> Get(GetPaymentTypesDto getPaymentTypesDto)
        {
            List<PaymentTypes> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getPaymentTypesDto.MembersId != Guid.Empty)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PaymentTypes).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getPaymentTypesDto.MembersId
                });
            }


            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<PaymentTypes>(filterExpressions).Compile();

                result = _context.Set<PaymentTypes>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<PaymentTypes>().ToList();
            }

            return await Task.Run(() => PagedList<PaymentTypes>
                                        .ToPagedList(result,
                                                     getPaymentTypesDto.PageNumber,
                                                     getPaymentTypesDto.PageSize));
        }
    }
}
