using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Feedback
{
    /// <summary>
    /// Feedback Filter Model
    /// </summary>
    public class FeedbackFilterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid FeedbackId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Rating
        /// </summary>
        public int Rating { get; set; }

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
