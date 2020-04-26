using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PointsOfSales Add(AddPointsOfSalesDto addPointsOfSalesDto)
        {
            PointsOfSales newPointOfSale = new PointsOfSales
            {
                Code = addPointsOfSalesDto.Code,
                Name = addPointsOfSalesDto.Name,
                StoresId = addPointsOfSalesDto.StoresId,
                MembersId = addPointsOfSalesDto.MembersId

            };

            _context.Set<PointsOfSales>().Add(newPointOfSale);
            _context.SaveChangesAsync(addPointsOfSalesDto.TableAuditEnum,
                                 addPointsOfSalesDto.AspNetUserId);

            return newPointOfSale;
        }

        public PointsOfSales Delete(DeletePointsOfSalesDto deletePointsOfSalesDto)
        {
            PointsOfSales pointOfSaleToDelte = (from g in _context.Set<PointsOfSales>()
                                         where g.PointsOfSalesId.Equals(deletePointsOfSalesDto.PointsOfSalesId)
                                         select g)
                                    .FirstOrDefault();

            _context.Set<PointsOfSales>().Remove(pointOfSaleToDelte);
            _context.SaveChangesAsync(deletePointsOfSalesDto.TableAuditEnum,
                                 deletePointsOfSalesDto.AspNetUserId);

            return pointOfSaleToDelte;
        }

        public Task<PagedList<PointsOfSales>> Get(GetPointsOfSalesDto getPointsOfSalesDto)
        {
            List<PointsOfSales> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getPointsOfSalesDto.MembersId != Guid.Empty)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PointsOfSales).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getPointsOfSalesDto.MembersId
                });
            }

            if (getPointsOfSalesDto.StoresId != Guid.Empty)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(PointsOfSales).GetProperties().First(p => p.Name == "StoresId"),
                    Operator = OperationsEnum.Equals,
                    Value = getPointsOfSalesDto.StoresId
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

            return Task.Run(()=> PagedList<PointsOfSales>.ToPagedList(result,
                                                        getPointsOfSalesDto.PageNumber,
                                                        getPointsOfSalesDto.PageSize));
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
            entry.Property("PointsOfSalesId").IsModified = false;
            entry.Property("MembersId").IsModified = false;

            _context.Set<PointsOfSales>().Update(pointsOfSaleToUpdate);
            _context.SaveChangesAsync(putPointsOfSalesDto.TableAuditEnum,
                                 putPointsOfSalesDto.AspNetUserId);

            return pointsOfSaleToUpdate;
        }
    }
}
