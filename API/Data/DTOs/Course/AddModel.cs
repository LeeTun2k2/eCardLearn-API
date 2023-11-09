using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Course
{
    /// <summary>
    /// Course Add Model
    /// </summary>
    public class CourseAddModel
    {
        /// <summary>
        /// Course Name
        /// </summary>
        [Required]
        public string CourseName { get; set; } = string.Empty;

        /// <summary>
        /// Course Description
        /// </summary>
        [Required]
        public string CourseDescription { get; set; } = string.Empty;

        /// <summary>
        /// Topic Id
        /// </summary>
        [Required]
        public Guid TopicId { get; set; }

        /// <summary>
        /// Teacher Created Id
        /// </summary>
        [Required]
        public Guid TeacherId { get; set; }

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
