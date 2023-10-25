namespace API.Services
{
    /// <summary>
    /// Base Service Interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="ViewModel"></typeparam>
    /// <typeparam name="AddModel"></typeparam>
    /// <typeparam name="EditModel"></typeparam>
    /// <typeparam name="FilterModel"></typeparam>
    public interface IBaseService<TEntity, ViewModel, AddModel, EditModel, FilterModel>
        where TEntity : class
        where ViewModel : class
        where AddModel : class
        where EditModel : class
        where FilterModel : class
    {
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ViewModel?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<ViewModel>?> GetAsync(FilterModel filter);

        /// <summary>
        /// Add 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ViewModel?> AddAsync(AddModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ViewModel?> UpdateAsync(Guid id, EditModel model);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id);
    }
}