namespace API.Data.Entities
{
    /// <summary>
    /// Feedback
    /// </summary>
    public class Feedback
    {   
        /// <summary>
        /// Id
        /// </summary>
        public Guid FeedbackId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public virtual Course? Course { get; set; }
    }
}
