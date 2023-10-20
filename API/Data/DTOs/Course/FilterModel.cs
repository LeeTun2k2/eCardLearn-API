using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Course
{
    /// <summary>
    /// Course Filter Model
    /// </summary>
    public class CourseFilterModel
    {
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
