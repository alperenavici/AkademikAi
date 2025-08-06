using AkademikAi.Data.IRepositories;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public int Count(Expression<Func<T, bool>>? expression = null)
        {
            return _repository.Count(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            return await _repository.CountAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public T? GetById(object id)
        {
            return _repository.GetById(id);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public T? GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _repository.GetFirstOrDefault(expression);
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetFirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _repository.GetWhere(expression);
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetWhereAsync(expression);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
} 