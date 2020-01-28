using System;
using System.Collections.Generic;
using System.Linq;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.Filters.PointsOfSales;
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
    public class PointsOfSalesRepository: RepositoryBase<PointsOfSales>, IPointsOfSalesRepository
    {
        public PointsOfSalesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PointsOfSales Delete(DeletePointsOfSalesDto deletePointsOfSalesDto)
        {
            PointsOfSales pointOfSaleToDelte = (from g in _context.Set<PointsOfSales>()
                                         where g.PointsOfSalesId.Equals(deletePointsOfSalesDto.PointOfSaleId)
                                         select g)
                                    .FirstOrDefault();

            _context.Set<PointsOfSales>().Remove(pointOfSaleToDelte);
            _context.SaveChanges(deletePointsOfSalesDto.TableAuditEnum,
                                 deletePointsOfSalesDto.AspNetUserId);

            return pointOfSaleToDelte;
        }

        public PagedList<PointsOfSales> Get(GetPointsOfSalesFilter getPointsOfSalesFilter)
        {
            List<PointsOfSales> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getPointsOfSalesFilter.PointOfSaleId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PointsOfSales).GetProperties().First(p => p.Name == "Id"),
                    Operator = OperationsEnum.Equals,
                    Value = getPointsOfSalesFilter.PointOfSaleId
                });
            }

            if (getPointsOfSalesFilter.Code != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PointsOfSales).GetProperties().First(p => p.Name == "Code"),
                    Operator = OperationsEnum.Equals,
                    Value = getPointsOfSalesFilter.Code
                });
            }

            if (getPointsOfSalesFilter.Name != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PointsOfSales).GetProperties().First(p => p.Name == "Name"),
                    Operator = OperationsEnum.Equals,
                    Value = getPointsOfSalesFilter.Name
                });
            }

            if (getPointsOfSalesFilter.MemberId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PointsOfSales).GetProperties().First(p => p.Name == "MemberId"),
                    Operator = OperationsEnum.Equals,
                    Value = getPointsOfSalesFilter.MemberId
                });
            }


            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<PointsOfSales>(filterExpressions).Compile();

                result = _context.Set<PointsOfSales>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<PointsOfSales>().ToList();
            }

            return PagedList<PointsOfSales>.ToPagedList(result,
                                                    getPointsOfSalesFilter.PageNumber,
                                                    getPointsOfSalesFilter.PageSize);
        }

        public PointsOfSales Update(PutPointsOfSalesDto putPointsOfSalesDto)
        {
            PointsOfSales pointsOfSaleToUpdate = (from g in _context.Set<PointsOfSales>()
                                          where g.PointsOfSalesId.Equals(putPointsOfSalesDto.PointOfSalesId)
                                          select g)
                                        .FirstOrDefault();

            if (putPointsOfSalesDto.Code != null)
            {
                pointsOfSaleToUpdate.Code = putPointsOfSalesDto.Code;
            }

            if (putPointsOfSalesDto.Name != null)
            {
                pointsOfSaleToUpdate.Name = putPointsOfSalesDto.Name;
            }


            EntityEntry entry = _context.Entry(pointsOfSaleToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("Id").IsModified = false;
            entry.Property("MembersId").IsModified = false;

            _context.Set<PointsOfSales>().Update(pointsOfSaleToUpdate);
            _context.SaveChanges(putPointsOfSalesDto.TableAuditEnum,
                                 putPointsOfSalesDto.AspNetUserId);

            return pointsOfSaleToUpdate;
        }
    }
}
