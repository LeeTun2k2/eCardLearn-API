using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Question
{
    /// <summary>
    /// Question Add Model
    /// </summary>
    public class QuestionAddModel
    {
        /// <summary>
        /// Question String
        /// </summary>
        [Required]
        public string QuestionString { get; set; } = string.Empty;

        /// <summary>
        /// Question Answer
        /// </summary>
        [Required]
        public Guid CorrectAnswerId { get; set; }

        /// <summary>
        /// Course
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
