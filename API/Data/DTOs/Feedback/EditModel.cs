using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Feedback
{
    /// <summary>
    /// Feedback Edit Model
    /// </summary>
    public class FeedbackEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid FeedbackId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Rating
        /// </summary>
        [Required]
        public int Rating { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        [Required]
        public Guid CourseId { get; set; }

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
