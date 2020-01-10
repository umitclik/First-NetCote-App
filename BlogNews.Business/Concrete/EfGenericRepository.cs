using BlogNews.Business.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogNews.Business.Concrete
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext context;

        public EfGenericRepository(DbContext ctx)
        {
            context = ctx;
        }


        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, List<string> includes = null)
        {
            IQueryable<T> resp = context.Set<T>();

            if (includes != null && includes.Count > 0)
            {
                foreach (var item in includes)
                {
                    resp = resp.Include(item);
                }
            }

            if (predicate != null)
            {
                resp = resp.Where(predicate);
            }
            return resp;// context.Set<T>();//.Include("Category"); 
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, List<string> includes = null)
        {

            if (includes != null && includes.Count > 0)
            {

                var resp2 = context.Set<T>().Include(includes[0].ToString());
                foreach (var item in includes)
                {
                    resp2 = resp2.Include(item);
                }
                return await resp2.ToListAsync();

            }
            return await context.Set<T>().ToListAsync();
        }

        public Task<int> Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
