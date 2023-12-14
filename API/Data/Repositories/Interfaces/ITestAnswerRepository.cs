using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// TestAnswer
    /// </summary>
    public interface ITestAnswerRepository : IBaseRepository<TestAnswer>
    {
        /// <summary>
        /// Get Tests by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        Task<IEnumerable<Test>> GetTestByStudentId(Guid StudentId);

        /// <summary>
        /// Get Student ids by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>> GetStudentIdByTestId(Guid TestId);

        /// <summary>
        /// Get TestAnswer by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        Task<IEnumerable<TestAnswer>?> Get(Guid TestId);

        /// <summary>
        /// Get TestAnswer by Test id and User id
        /// </summary>
        /// <param name="TestId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<TestAnswer>?> Get(Guid TestId, Guid UserId);
    }
}
