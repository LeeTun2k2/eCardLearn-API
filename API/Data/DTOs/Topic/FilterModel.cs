namespace API.Data.DTOs.Topic
{
    /// <summary>
    /// Topic Filter Model
    /// </summary>
    public class TopicFilterModel
    {
        /// <summary>
        /// Topic Name
        /// </summary>
        public string? TopicName { get; set; } = string.Empty;

        /// <summary>
        /// Topic Description
        /// </summary>
        public string? TopicDescription { get; set; } = string.Empty;

        /// <summary>
        /// Page Number
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        public int? PageSize { get; set; }
    }
}
