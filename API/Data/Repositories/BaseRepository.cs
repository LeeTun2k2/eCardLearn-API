using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using API.Commons.Paginations;

namespace API.Data.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Db Set
        /// </summary>
        public DbSet<T> Entities { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public BaseRepository(DataContext context, IUnitOfWork unitOfWork)
        {
            Entities = context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T?> AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
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
            await Entities.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>?> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, PaginationParameters? pagination = null)
        {
            IQueryable<T> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pagination != null)
            {
                if (pagination.PageNumber < 1)
                {
                    pagination.PageNumber = 1; // Ensure the page number is at least 1
                }

                if (pagination.PageSize < 1)
                {
                    pagination.PageSize = 10; // Default page size
                }

                int itemsToSkip = (pagination.PageNumber - 1) * pagination.PageSize;

                query = query.Skip(itemsToSkip).Take(pagination.PageSize);
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
            return await Entities.FindAsync(id);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(T entity)
        {
            Entities.Remove(entity);
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
            Entities.RemoveRange(entities);
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
            Entities.Update(entity);
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
            Entities.UpdateRange(entities);
            await _unitOfWork.SaveChangesAsync();
            return entities;
        }
    }
}
