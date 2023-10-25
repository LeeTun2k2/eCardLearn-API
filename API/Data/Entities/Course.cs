namespace API.Data.Entities
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid CourseId { get; set; }
        /// <summary>
        /// Course Name
        /// </summary>
        public string CourseName { get; set; } = string.Empty;

        /// <summary>
        /// Course Description
        /// </summary>
        public string CourseDescription { get; set; } = string.Empty;

        /// <summary>
        /// Topic Id
        /// </summary>
        public Guid TopicId { get; set; }

        /// <summary>
        /// Topic
        /// </summary>
        public virtual Topic? Topic { get; set; }

        /// <summary>
        /// Teacher Created Id
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Teacher Created
        /// </summary>
        public virtual Teacher? Teacher { get; set; }

        /// <summary>
        /// Feedbacks
        /// </summary>
        public virtual IEnumerable<Feedback>? Feedbacks { get; set; }

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
