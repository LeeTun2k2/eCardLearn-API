namespace API.Data.DTOs.TestAnswer
{
    /// <summary>
    /// TestAnswer View Model
    /// </summary>
    public class TestAnswerViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid TestAnswerId { get; set; }

        /// <summary>
        /// Test Id
        /// </summary>
        public Guid TestId { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Question Id
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Answer Id
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Created User Id
        /// </summary>
        public Guid? CreatedUserId { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Updated User Id
        /// </summary>
        public Guid? UpdatedUserId { get; set; }

        /// <summary>
        /// Updated User Date
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
