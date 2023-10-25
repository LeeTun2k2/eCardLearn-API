namespace API.Data.DTOs.Answer
{
    /// <summary>
    /// Answer View Model
    /// </summary>
    public class AnswerViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Answer String
        /// </summary>
        public string AnswerString { get; set; } = string.Empty;

        /// <summary>
        /// Question
        /// </summary>
        public Guid QuestionId { get; set; }

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
