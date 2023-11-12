using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Feedback
    /// </summary>
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {
        /// <summary>
        /// Get Feedback by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<Feedback>> GetByUserId(Guid UserId);

        /// <summary>
        /// Get Feedback by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<Feedback>> GetByCourseId(Guid CourseId);
    }
}
