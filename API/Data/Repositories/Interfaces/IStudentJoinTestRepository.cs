using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// StudentJoinTest
    /// </summary>
    public interface IStudentJoinTestRepository : IBaseRepository<StudentJoinTest>
    {
        /// <summary>
        /// Get Testes by Student id
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
    }
}
