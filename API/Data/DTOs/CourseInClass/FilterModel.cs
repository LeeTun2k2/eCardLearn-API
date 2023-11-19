using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.CourseInClass
{
    /// <summary>
    /// CourseInClass Filter Model
    /// </summary>
    public class CourseInClassFilterModel
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
