using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IRepositoryBase<T>
    {
        List<T> ObtieneTodos();
        List<T> ObtienePorFiltro(Expression<Func<T, bool>> expression);
        T Crear(T entity);
        T Actualizar(T entity);
        T Borrar(T entity);
    }
}
