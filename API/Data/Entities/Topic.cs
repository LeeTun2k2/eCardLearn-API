namespace API.Data.Entities
{
    /// <summary>
    /// Topic
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid TopicId { get; set; }
        /// <summary>
        /// Topic Name
        /// </summary>
        public string TopicName { get; set; } = string.Empty;

        /// <summary>
        /// Topic Description
        /// </summary>
        public string TopicDescription { get; set; } = string.Empty;
    }
}
