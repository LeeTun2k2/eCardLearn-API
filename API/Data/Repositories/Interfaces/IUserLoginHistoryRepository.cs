using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// UserLoginHistory
    /// </summary>
    public interface IUserLoginHistoryRepository : IBaseRepository<UserLoginHistory>
    {
        /// <summary>
        /// Get latest record
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<UserLoginHistory?> GetLatest(Guid UserId);

        /// <summary>
        /// get by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserLoginHistory>?> GetByUserId(Guid UserId);
    }
}
