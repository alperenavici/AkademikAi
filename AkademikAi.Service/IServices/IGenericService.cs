using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IGenericService<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        T? GetById(object id);
        T? GetFirstOrDefault(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        bool Any(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>>? expression = null);

        Task<T?> GetByIdAsync(object id);
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
    }
} 