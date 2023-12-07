using API.Data.DTOs.Authentication;
using API.Data.DTOs.Class;

namespace API.Data.DTOs.TestResult
{
    /// <summary>
    /// TestResult 
    /// </summary>
    public class TestResult_Summary
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid SummaryId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Fullname
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Số câu đúng
        /// </summary>
        public int NoCorrectAnswer { get; set; } = 0;

        /// <summary>
        /// Số câu sai
        /// </summary>
        public int NoIncorrectAnswer { get; set; } = 0;
    }
}
