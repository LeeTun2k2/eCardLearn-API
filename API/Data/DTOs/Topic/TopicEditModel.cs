﻿namespace API.Data.DTOs.Topic
{
    /// <summary>
    /// Topic Edit Model
    /// </summary>
    public class TopicEditModel
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
