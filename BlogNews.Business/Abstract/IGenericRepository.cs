using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace BlogNews.Business.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, List<string> includes = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, List<string> includes = null);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task<int> Save();
    }
}
