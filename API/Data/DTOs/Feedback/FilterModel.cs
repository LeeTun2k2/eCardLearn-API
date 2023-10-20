using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Feedback
{
    /// <summary>
    /// Feedback Filter Model
    /// </summary>
    public class FeedbackFilterModel
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
