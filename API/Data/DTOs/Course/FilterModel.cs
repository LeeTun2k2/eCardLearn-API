using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Course
{
    /// <summary>
    /// Course Filter Model
    /// </summary>
    public class CourseFilterModel
    {
        /// <summary>
        /// Course Name
        /// </summary>
        public string CourseName { get; set; } = string.Empty;

        /// <summary>
        /// Course Description
        /// </summary>
        public string CourseDescription { get; set; } = string.Empty;

        /// <summary>
        /// Page Number
        /// </summary>
        
        [Required]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        [Required]
        public int? PageSize { get; set; }
    }
}
