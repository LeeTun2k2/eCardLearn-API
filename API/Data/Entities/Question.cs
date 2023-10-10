namespace api.Data.Entities
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
        public Guid CorrectAnswer { get; set; }
    }
}
