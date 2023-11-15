using API.Data.DTOs.Authentication;
using API.Data.DTOs.Test;
using API.Data.DTOs.StudentJoinTest;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// StudentJoinTest Service Interface
    /// </summary>
    public interface IStudentJoinTestService : IBaseService<StudentJoinTest, StudentJoinTestViewModel, StudentJoinTestAddModel, StudentJoinTestEditModel, StudentJoinTestFilterModel>
    {
        /// <summary>
        /// Get Test by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        Task<IEnumerable<TestViewModel>?> GetTestByStudentId(Guid StudentId);

        /// <summary>
        /// Get Student by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProfileModel>?> GetStudentByTestId(Guid TestId);
    }
}
