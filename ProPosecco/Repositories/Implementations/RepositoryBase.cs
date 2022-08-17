using Microsoft.EntityFrameworkCore;
using ProPosecco.Areas.Identity.Data;
using ProProsecco.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProProsecco.Repositories.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ProProseccoDbContext Context { get; set; }

        public RepositoryBase(ProProseccoDbContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> GetByCondtion(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public void Create(T entity)
        {
            Context.Set<T>()
                .Add(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>()
                .Update(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>()
                .Remove(entity);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
