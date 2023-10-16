namespace API.Data.Repositories
{
    /// <summary>
    /// Unit of Work Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit Transaction
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        Task RollbackTransactionAsync();

        /// <summary>
        /// Save Changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Begin Transaction
        /// </summary>
        Task BeginTransactionAsync();
    }

}
