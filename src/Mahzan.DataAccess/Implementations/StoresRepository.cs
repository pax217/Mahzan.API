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

namespace Mahzan.DataAccess.Implementations
{
    public class StoresRepository: RepositoryBase<Stores>, IStoresRepository
    {
        public StoresRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Stores> Get(GetStoresFilter getStoresFilter)
        {
            List<Stores> result = null;

            if (getStoresFilter.StoreId == Guid.Empty
                && getStoresFilter.Code == null
                && getStoresFilter.Name == null
                && getStoresFilter.CompanyId ==Guid.Empty)
            {
                result = (from g in _context.Set<Stores>()
                          select g)
                         .ToList();
            }
            else
            {
                if (getStoresFilter.StoreId == Guid.Empty
                    && getStoresFilter.Code != null
                    && getStoresFilter.Name != null
                    && getStoresFilter.CompanyId != Guid.Empty)
                {
                    result = (from g in _context.Set<Stores>()
                              where g.Id == getStoresFilter.StoreId
                              && g.Code == getStoresFilter.Code
                              && g.Name.Contains(getStoresFilter.Name)
                              && g.CompanyId.Equals(getStoresFilter.CompanyId)
                              select g)
                             .ToList();
                }
                else if (getStoresFilter.StoreId != Guid.Empty)
                {
                    result = (from g in _context.Set<Stores>()
                              where g.Id == getStoresFilter.StoreId
                              select g)
                              .ToList();
                }
                else if (getStoresFilter.Code != null)
                {
                    result = (from g in _context.Set<Stores>()
                              where g.Code == getStoresFilter.Code
                              select g)
                              .ToList();
                }
                else if (getStoresFilter.Name != null)
                {
                    result = (from g in _context.Set<Stores>()
                              where g.Name == getStoresFilter.Name
                              select g)
                              .ToList();
                }
                else if (getStoresFilter.CompanyId != Guid.Empty)
                {
                    result = (from g in _context.Set<Stores>()
                              where g.CompanyId == getStoresFilter.CompanyId
                              select g)
                              .ToList();
                }
            }

            return PagedList<Stores>.ToPagedList(result,
                                                 getStoresFilter.PageNumber,
                                                 getStoresFilter.PageSize);
        }

        public Stores Update(PutStoresDto putStoresDto)
        {
            Stores storesToUpdate = (from g in _context.Set<Stores>()
                                    where g.Id.Equals(putStoresDto.StoreId)
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

            if (putStoresDto.Active != null)
            {
                storesToUpdate.Active = putStoresDto.Active.Value;
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
                                   where g.Id.Equals(deleteStoresDto.StoreId)
                                   select g)
                                   .FirstOrDefault();

            _context.Set<Stores>().Remove(storeToDelte);
            _context.SaveChanges(deleteStoresDto.TableAuditEnum,
                                 deleteStoresDto.AspNetUserId);

            return storeToDelte;
        }
    }
}
