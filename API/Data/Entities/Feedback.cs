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
