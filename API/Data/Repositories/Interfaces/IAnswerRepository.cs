using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Answer
    /// </summary>
    public interface IAnswerRepository : IBaseRepository<Answer>
    {
        /// <summary>
        /// Get Answer by Question id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Answer>> GetByQuestionId(Guid QuestionId);

        /// <summary>
        /// Get Answer by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<Answer>> GetByCourseId(Guid CourseId);
    }
}
