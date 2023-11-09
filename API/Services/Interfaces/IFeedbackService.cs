using API.Data.DTOs.Feedback;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Feedback Service Interface
    /// </summary>
    public interface IFeedbackService : IBaseService<Feedback, FeedbackViewModel, FeedbackAddModel, FeedbackEditModel, FeedbackFilterModel>
    {
        /// <summary>
        /// Get Feedback by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<FeedbackViewModel>> GetByUserId(Guid UserId);

        /// <summary>
        /// Get Feedback by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<FeedbackViewModel>> GetByCourseId(Guid CourseId);
    }
}
