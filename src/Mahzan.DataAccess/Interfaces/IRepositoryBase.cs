using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll();
        List<T> Get(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
