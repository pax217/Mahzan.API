using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
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

        public List<T> ObtieneTodos()
        {
            return this._context.Set<T>().AsNoTracking().ToList();
        }

        public List<T> ObtienePorFiltro(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking().ToList();
        }

        public T Crear(T entity)
        {
            this._context.Set<T>().Add(entity);
            this._context.SaveChangesAsync();

            return entity;
        }

        public T Actualizar(T entity)
        {
            this._context.Set<T>().Update(entity);
            this._context.SaveChangesAsync();

            return entity;
        }

        public T Borrar(T entity)
        {
            this._context.Set<T>().Remove(entity);
            this._context.SaveChangesAsync();

            return entity;
        }
    }
}
