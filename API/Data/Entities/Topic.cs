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
