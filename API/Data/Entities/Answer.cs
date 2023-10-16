namespace API.Data.Entities
{
    /// <summary>
    /// Answer
    /// </summary>
    public class Answer
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
        /// Question
        /// </summary>
        public virtual Question? Question { get; set; }
    }
}
