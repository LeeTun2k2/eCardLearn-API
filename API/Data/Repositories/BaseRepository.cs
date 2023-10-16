﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace API.Data.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public BaseRepository(DataContext context, IUnitOfWork unitOfWork)
        {
            _entities = context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T?> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync(); 
            return entity;
        }

        /// <summary>
        /// Add multiple
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>?> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(T entity)
        {
            _entities.Remove(entity);
            await _unitOfWork.SaveChangesAsync(); 
            return true;
        }

        /// <summary>
        /// Remove multiple
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T?> UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Update multiple
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>?> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _entities.UpdateRange(entities);
            await _unitOfWork.SaveChangesAsync();
            return entities;
        }
    }
}
