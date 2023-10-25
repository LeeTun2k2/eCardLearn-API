using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.StudentJoinClass
{
    /// <summary>
    /// StudentJoinClass Filter Model
    /// </summary>
    public class StudentJoinClassFilterModel
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
