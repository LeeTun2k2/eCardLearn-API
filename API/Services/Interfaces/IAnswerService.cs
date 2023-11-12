using API.Data.DTOs.Answer;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Answer Service Interface
    /// </summary>
    public interface IAnswerService : IBaseService<Answer, AnswerViewModel, AnswerAddModel, AnswerEditModel, AnswerFilterModel>
    {
        /// <summary>
        /// Get Answer by Question id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        Task<IEnumerable<AnswerViewModel>> GetByQuestionId(Guid QuestionId);

        /// <summary>
        /// Get Answer by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<AnswerViewModel>> GetByCourseId(Guid CourseId);
    }
}
