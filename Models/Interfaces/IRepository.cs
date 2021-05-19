using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DogAndPeoples.Models.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T> Insert(T entity);
        Task<T> FindById(Guid id);
        Task<List<T>> FindAlls();
        Task Update(T entity);
        Task Remove(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}