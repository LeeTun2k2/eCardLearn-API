using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Question
    /// </summary>
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        /// <summary>
        /// Get Question by id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        Task<Question?> GetById(Guid QuestionId);

        /// <summary>
        /// Get Question by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<Question>> GetByCourseId(Guid CourseId);
    }
}
