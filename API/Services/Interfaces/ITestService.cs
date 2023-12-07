using API.Data.DTOs.Test;
using API.Data.DTOs.TestResult;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Test Service Interface
    /// </summary>
    public interface ITestService : IBaseService<Test, TestViewModel, TestAddModel, TestEditModel, TestFilterModel>
    {
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        Task<TestViewModel?> GetById(Guid TestId);

        /// <summary>
        /// Get Test by created user id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<TestViewModel>?> GetTestsByCreatedUserId(Guid UserId);

        /// <summary>
        /// Summary Report
        /// </summary>
        /// <param name="TestId"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<TestResult_Summary>?> SummaryReport(Guid TestId, Guid? ClassId);

        /// <summary>
        /// Detail Report
        /// </summary>
        /// <param name="TestId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<IEnumerable<TestResult_Detail>?> DetailReport(Guid TestId, Guid UserId);
    }
}
