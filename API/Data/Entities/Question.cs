namespace API.Data.Entities
{
    /// <summary>
    /// Question
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid QuestionId { get; set; }
        /// <summary>
        /// Question String
        /// </summary>
        public string QuestionString { get; set; } = string.Empty;

        /// <summary>
        /// Question Answer
        /// </summary>
        public Guid CorrectAnswerId { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public virtual Course? Course { get; set; }

        /// <summary>
        /// Answer
        /// </summary>
        public virtual IEnumerable<Answer>? Answers { get; set; }

        /// <summary>
        /// TestAnswer
        /// </summary>
        public virtual IEnumerable<TestAnswer>? TestAnswers { get; set; }

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
