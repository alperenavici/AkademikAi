using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkademikAi.Data.IRepositories;
using AkademikAi.Data.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AkademikAi.Data.Repositories
{
    public class GenericRepository <T>:IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual bool Any(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public virtual int Count(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null ? _dbSet.Count() : _dbSet.Count(expression);
        }

        // Async methods
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(expression);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
    }
}
