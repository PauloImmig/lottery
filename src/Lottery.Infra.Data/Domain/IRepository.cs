using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lottery.Infra.Data.Domain
{
    public interface IRepository<T>
    {
        T GetById(object id);
        T[] GetAll();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}
