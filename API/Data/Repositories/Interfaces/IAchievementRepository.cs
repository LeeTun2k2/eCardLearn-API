using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Achievement
    /// </summary>
    public interface IAchievementRepository : IBaseRepository<Achievement>
    {
        /// <summary>
        /// Get by number of day
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        Task<Achievement?> GetByDay(int day);
    }
}
