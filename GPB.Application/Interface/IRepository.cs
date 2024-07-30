﻿using System.Linq.Expressions;

namespace GPB.Application.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity); 
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
       
    }
}
