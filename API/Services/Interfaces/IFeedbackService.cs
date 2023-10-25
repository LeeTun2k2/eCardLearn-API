using API.Data.DTOs.Feedback;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Feedback Service Interface
    /// </summary>
    public interface IFeedbackService : IBaseService<Feedback, FeedbackViewModel, FeedbackAddModel, FeedbackEditModel, FeedbackFilterModel>
    {

    }
}
