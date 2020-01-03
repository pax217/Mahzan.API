using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mahzan.Models.Enums.Audit;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll();

        List<T> Get(Expression<Func<T, bool>> expression);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        T Add(T entity,
              Guid aspNetUserId,
              TableAuditEnum tableAuditEnum);

        T Update(T entity,
              Guid aspNetUserId,
              TableAuditEnum tableAuditEnum);
    }
}
