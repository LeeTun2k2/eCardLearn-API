using API.Data.DTOs.Question;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Question Service Interface
    /// </summary>
    public interface IQuestionService : IBaseService<Question, QuestionViewModel, QuestionAddModel, QuestionEditModel, QuestionFilterModel>
    {
        /// <summary>
        /// Get Question by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<QuestionViewModel>> GetByCourseId(Guid CourseId);

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        Task<QuestionViewModel?> GetById(Guid QuestionId);

        /// <summary>
        /// Generate Course By Open Trivia DB
        /// </summary>
        /// <param name="OpenTriviaDbCategoryId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<IEnumerable<QuestionViewModel>?> GenerateByOpenTriviaDB(Guid OpenTriviaDbCategoryId, int number);
    }
}
