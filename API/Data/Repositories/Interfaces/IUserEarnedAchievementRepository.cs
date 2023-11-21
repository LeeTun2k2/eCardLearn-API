using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// UserEarnedAchievement
    /// </summary>
    public interface IUserEarnedAchievementRepository : IBaseRepository<UserEarnedAchievement>
    {
        /// <summary>
        /// Get User ids by Achievement id
        /// </summary>
        /// <param name="AchievementId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>?> GetUserIdByAchivementId(Guid AchievementId);

        /// <summary>
        /// Get Achievements by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<Achievement>?> GetAchievementsByUserId(Guid UserId);
    }
}
