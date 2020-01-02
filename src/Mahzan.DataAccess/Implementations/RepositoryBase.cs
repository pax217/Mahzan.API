using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Enums.Audit;
using Microsoft.EntityFrameworkCore;

namespace Mahzan.DataAccess.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MahzanDbContext _context { get; set; }

        public RepositoryBase(MahzanDbContext repositoryContext)
        {
            this._context = repositoryContext;
        }

        public List<T> GetAll()
        {
            return this._context.Set<T>().AsNoTracking().ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking().ToList();
        }

        public T Add(T entity)
        {
            this._context.Set<T>().Add(entity);
            this._context.SaveChangesAsync();

            return entity;
        }

        public T Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            this._context.SaveChangesAsync();

            return entity;
        }

        public T Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            this._context.SaveChangesAsync();

            return entity;
        }

        public T Add(T entity,
                     Guid aspNetUserId,
                     TableAuditEnum tableAuditEnum)
        {
            this._context.Set<T>().Add(entity);
            this._context.SaveChanges(tableAuditEnum, aspNetUserId);

            return entity;
        }
    }
}
