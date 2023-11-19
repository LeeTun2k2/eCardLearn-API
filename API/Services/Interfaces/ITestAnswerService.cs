using API.Data.DTOs.Test;
using API.Data.DTOs.TestAnswer;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// TestAnswer Service Interface
    /// </summary>
    public interface ITestAnswerService : IBaseService<TestAnswer, TestAnswerViewModel, TestAnswerAddModel, TestAnswerEditModel, TestAnswerFilterModel>
    {

    }
}
