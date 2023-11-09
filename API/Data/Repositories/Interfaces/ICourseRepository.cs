using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Course
    /// </summary>
    public interface ICourseRepository : IBaseRepository<Course>
    {
        /// <summary>
        /// Get Course by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<Course>> GetByTeacherId(Guid TeacherId);

        /// <summary>
        /// Get Course by Topic id
        /// </summary>
        /// <param name="TopicId"></param>
        /// <returns></returns>
        Task<IEnumerable<Course>> GetByTopicId(Guid TopicId);
    }
}
