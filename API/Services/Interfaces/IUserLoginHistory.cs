using API.Data.DTOs.UserLoginHistory;
namespace API.Services.Interfaces
{
    /// <summary>
    /// UserLoginHistory Service Interface
    /// </summary>
    public interface IUserLoginHistoryService
    {
        /// <summary>
        /// Write Login history
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<bool> WriteLoginHistory(Guid UserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserLoginHistoryViewModel>?> GetUserLoginHistory(Guid UserId);
    }
}
