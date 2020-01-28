using System;
using System.Collections.Generic;
using Mahzan.DataAccess.Filters.Stores;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.Models.Expressions;
using Mahzan.Models.Enums.Expressions;

namespace Mahzan.DataAccess.Implementations
{
    public class StoresRepository: RepositoryBase<Stores>, IStoresRepository
    {
        public StoresRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Stores> Get(GetStoresDto getStoresDto)
        {
            List<Stores> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            //MembersId
            if (getStoresDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Stores).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getStoresDto.MembersId
                });
            }

            //StoresId
            if (getStoresDto.StoresId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Stores).GetProperties().First(p => p.Name == "StoresId"),
                    Operator = OperationsEnum.Equals,
                    Value = getStoresDto.StoresId
                });
            }

            //Name
            if (getStoresDto.Name != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Stores).GetProperties().First(p => p.Name == "Name"),
                    Operator = OperationsEnum.Equals,
                    Value = getStoresDto.Name
                });
            }

            //Companies
            if (getStoresDto.CompaniesId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Stores).GetProperties().First(p => p.Name == "CompaniesId"),
                    Operator = OperationsEnum.Equals,
                    Value = getStoresDto.CompaniesId
                });
            }

            return PagedList<Stores>.ToPagedList(result,
                                                 getStoresDto.PageNumber,
                                                 getStoresDto.PageSize);
        }

        public Stores Update(PutStoresDto putStoresDto)
        {
            Stores storesToUpdate = (from g in _context.Set<Stores>()
                                    where g.StoresId.Equals(putStoresDto.StoreId)
                                    select g)
                                   .FirstOrDefault();

            //Cambios
            if (putStoresDto.Code != null)
            {
                storesToUpdate.Code = putStoresDto.Code;
            }

            if (putStoresDto.Name != null)
            {
                storesToUpdate.Name = putStoresDto.Name;
            }

            if (putStoresDto.Phone != null)
            {
                storesToUpdate.Phone = putStoresDto.Phone;
            }

            if (putStoresDto.Comment != null)
            {
                storesToUpdate.Comment = putStoresDto.Comment;
            }


            EntityEntry entry = _context.Entry(storesToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("Id").IsModified = false;

            _context.Set<Stores>().Update(storesToUpdate);
            _context.SaveChanges(putStoresDto.TableAuditEnum,
                                 putStoresDto.AspNetUserId);

            return storesToUpdate;

        }

        public Stores Delete(DeleteStoresDto deleteStoresDto)
        {
            Stores storeToDelte = (from g in _context.Set<Stores>()
                                   where g.StoresId.Equals(deleteStoresDto.StoreId)
                                   select g)
                                   .FirstOrDefault();

            _context.Set<Stores>().Remove(storeToDelte);
            _context.SaveChanges(deleteStoresDto.TableAuditEnum,
                                 deleteStoresDto.AspNetUserId);

            return storeToDelte;
        }
    }
}
