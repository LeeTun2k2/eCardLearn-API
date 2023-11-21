using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// UserEarnedAchievement Repository
    /// </summary>
    public class UserEarnedAchievementRepository : BaseRepository<UserEarnedAchievement>, IUserEarnedAchievementRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public UserEarnedAchievementRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Achievement by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Achievement>?> GetAchievementsByUserId(Guid UserId)
        {
            return await Entities
                .Where(x => x.UserId == UserId)
                .Include(x => x.Achievement)
                .AsNoTracking()
                .Select(x => x.Achievement!)
                .ToListAsync();
        }

        /// <summary>
        /// Get User id by Achievement id
        /// </summary>
        /// <param name="AchievementId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>?> GetUserIdByAchivementId(Guid AchievementId)
        {
            return await Entities
                .Where(x => x.AchievementId == AchievementId)
                .AsNoTracking()
                .Select(x => x.UserId)
                .ToListAsync();  
        }
    }
}
