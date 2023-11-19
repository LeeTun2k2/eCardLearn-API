namespace API.Data.Entities
{
    /// <summary>
    /// CourseInClass
    /// </summary>
    public class CourseInClass
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid CourseInClassId { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public Course? Course { get; set; }

        /// <summary>
        /// Class Id
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public Class? Class { get; set; }

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
