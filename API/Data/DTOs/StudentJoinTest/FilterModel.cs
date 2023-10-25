using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.StudentJoinTest
{
    /// <summary>
    /// StudentJoinTest Filter Model
    /// </summary>
    public class StudentJoinTestFilterModel
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
