using System;
using System.Collections.Generic;

namespace Billing.RepositoryPattern.Shared.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        int Complete();
    }
}
