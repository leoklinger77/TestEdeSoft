using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;
using Test.Models.Interfaces;

namespace Test.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DataContext _context;
        public readonly DbSet<T> DbSet;

        public Repository(DataContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public async Task<T> Insert(T entity)
        {
             DbSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<T>> FindAlls()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> FindById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remove(int id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public virtual async Task Update(T entity)
        {
            DbSet.UpdateRange(entity);
            await SaveChanges();
        }        
    }
}
