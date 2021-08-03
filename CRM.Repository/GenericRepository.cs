using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CRM.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private AdlinkContext context;
        public GenericRepository(AdlinkContext _context)
        {
            this.context = _context;
        }
        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var entity = context.Set<T>().Find(id);
            context.Set<T>().Remove(entity);
        }
        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        
        public T GetOneBy(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }
       
    }
}
