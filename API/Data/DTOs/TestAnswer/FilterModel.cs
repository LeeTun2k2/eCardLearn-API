using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.TestAnswer
{
    /// <summary>
    /// TestAnswer Filter Model
    /// </summary>
    public class TestAnswerFilterModel
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
