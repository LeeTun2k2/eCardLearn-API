namespace api.Data.Entities
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
    }
}
