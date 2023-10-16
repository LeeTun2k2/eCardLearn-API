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
    }
}
