using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.DataAccess.DTO.PaymentTypes;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

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
            PaymentTypes newPaymentTypes = _mapper.Map<PaymentTypes>(addPaymentTypesDto);

            _context.Set<PaymentTypes>().Add(newPaymentTypes);

            await _context.SaveChangesAsync();

            return newPaymentTypes;
        }
    }
}
