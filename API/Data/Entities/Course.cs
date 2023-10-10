namespace api.Data.Entities
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
    }
}
