using API.Data.DTOs.Authentication;
using API.Data.DTOs.Achievement;
using API.Data.DTOs.UserEarnedAchievement;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// UserEarnedAchievement Service Interface
    /// </summary>
    public interface IUserEarnedAchievementService : IBaseService<UserEarnedAchievement, UserEarnedAchievementViewModel, UserEarnedAchievementAddModel, UserEarnedAchievementEditModel, UserEarnedAchievementFilterModel>
    {

        /// <summary>
        /// Get Achievement by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<AchievementViewModel>?> GetAchievementByUserId(Guid UserId);

        /// <summary>
        /// Get User by Achievement id
        /// </summary>
        /// <param name="AchievementId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProfileModel>?> GetUserByAchievementId(Guid AchievementId);
    }
}
