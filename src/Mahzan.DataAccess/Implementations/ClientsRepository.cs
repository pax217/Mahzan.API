using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;

namespace Mahzan.DataAccess.Implementations
{
    public class ClientsRepository: RepositoryBase<Clients>, IClientsRepository
    {
        readonly IMapper _mapper;

        public ClientsRepository(
            MahzanDbContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public async Task<Clients> Add(AddClientsDto addClientsDto)
        {
            Clients newClient = null;

            newClient = new Clients
            {
                Email = addClientsDto.Email,
                Phone = addClientsDto.Phone,
                Notes = addClientsDto.Notes,
                MembersId = addClientsDto.MembersId
            };

            _context.Set<Clients>().Add(newClient);
            _context.SaveChanges();

            return newClient;
        }

        public PagedList<Clients> Get(GetClientsDto getClientsDto)
        {
            List<Clients> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            //MemberId
            if (getClientsDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Clients).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getClientsDto.MembersId
                });
            }

            //Name
            if (getClientsDto.Name!=null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Clients).GetProperties().First(p => p.Name == "Name"),
                    Operator = OperationsEnum.Equals,
                    Value = getClientsDto.Name
                });
            }


            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Clients>(filterExpressions).Compile();

                result = _context.Set<Clients>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Clients>().ToList();
            }

            return PagedList<Clients>.ToPagedList(result,
                                                 getClientsDto.PageNumber,
                                                 getClientsDto.PageSize);
        }
    }
}
