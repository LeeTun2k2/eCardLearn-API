using API.Data.DTOs.Answer;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Answer Service Interface
    /// </summary>
    public interface IAnswerService : IBaseService<Answer, AnswerViewModel, AnswerAddModel, AnswerEditModel, AnswerFilterModel>
    {

    }
}
