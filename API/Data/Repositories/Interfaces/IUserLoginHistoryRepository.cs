using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// UserLoginHistory
    /// </summary>
    public interface IUserLoginHistoryRepository : IBaseRepository<UserLoginHistory>
    {
        Task<UserLoginHistory> GetLatest();
        Task<IEnumerable<UserLoginHistory>> GetByUserId(Guid UserId);
    }
}
