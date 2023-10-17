namespace API.Data.DTOs.Topic
{
    /// <summary>
    /// Topic Add Model
    /// </summary>
    public class TopicAddModel
    {
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
