using System.Linq.Expressions;

namespace API.Data.Repositories
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>?> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        Task<T?> AddAsync(T entity);

        /// <summary>
        /// Add range of entities
        /// </summary>
        /// <param name="entities"></param>
        Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> RemoveAsync(T entity);

        /// <summary>
        /// Remove range of entities
        /// </summary>
        /// <param name="entities"></param>
        Task<bool> RemoveRangeAsync(IEnumerable<T> entities);


        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        Task<T?> UpdateAsync(T entity);

        /// <summary>
        /// Update range of entities
        /// </summary>
        /// <param name="entities"></param>
        Task<IEnumerable<T>?> UpdateRangeAsync(IEnumerable<T> entities);
    }
}
