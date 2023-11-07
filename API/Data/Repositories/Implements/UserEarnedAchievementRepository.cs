using API.Data.Entities;
using API.Data.Repositories.Interfaces;

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
    }
}
