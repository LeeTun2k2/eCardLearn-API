using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Test
    /// </summary>
    public interface ITestRepository : IBaseRepository<Test>
    {
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        Task<Test?> GetById(Guid TestId);

        /// <summary>
        /// Get Tests by created user id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<Test>?> GetTestsByCreatedUserId(Guid UserId);
    }
}
