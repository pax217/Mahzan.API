using System;
using System.Collections.Generic;
using System.Linq;
using Mahzan.DataAccess.DTO.Taxes;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;

namespace Mahzan.DataAccess.Implementations
{
    public class TaxesRepository: RepositoryBase<Taxes>, ITaxesRepository
    {
        public TaxesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Taxes Add(AddTaxesDto addTaxesDto)
        {
            Taxes newTax = new Taxes
            {
                Name = addTaxesDto.Name,
                TaxRate = addTaxesDto.TaxRate,
                TaxType = addTaxesDto.TaxType,
                TaxOption = addTaxesDto.TaxOption,
                MembersId = addTaxesDto.MembersId
            };

            _context.Set<Taxes>().Add(newTax);
            _context.SaveChangesAsync(addTaxesDto.TableAuditEnum,
                                      addTaxesDto.AspNetUserId);

            return newTax;
        }

        public PagedList<Taxes> Get(GetTaxesDto getTaxesDto)
        {
            List<Taxes> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            //Members
            if (getTaxesDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Taxes).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getTaxesDto.MembersId
                });
            }

            //Name
            if (getTaxesDto.Name!=null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Taxes).GetProperties().First(p => p.Name == "Name"),
                    Operator = OperationsEnum.Equals,
                    Value = getTaxesDto.Name
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Taxes>(filterExpressions).Compile();

                result = _context.Set<Taxes>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Taxes>().ToList();
            }

            return PagedList<Taxes>.ToPagedList(result,
                                                getTaxesDto.PageNumber,
                                                getTaxesDto.PageSize);
        }
    }
}
