using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProProsecco.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetByCondtion(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Save();
    }
}
