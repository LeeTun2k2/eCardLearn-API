using API.Data.DTOs.Question;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Question Service Interface
    /// </summary>
    public interface IQuestionService : IBaseService<Question, QuestionViewModel, QuestionAddModel, QuestionEditModel, QuestionFilterModel>
    {

    }
}
