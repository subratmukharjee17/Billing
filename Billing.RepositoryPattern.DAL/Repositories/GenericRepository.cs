using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Billing.RepositoryPattern.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbcontext;
        public GenericRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
        }

        public T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

       
        public void Remove(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>().ToList();
        }

        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }

    }
}
