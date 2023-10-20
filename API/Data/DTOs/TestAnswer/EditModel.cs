using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.TestAnswer
{
    /// <summary>
    /// TestAnswer Edit Model
    /// </summary>
    public class TestAnswerEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid TestAnswerId { get; set; }

        /// <summary>
        /// Test Id
        /// </summary>
        [Required]
        public Guid TestId { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        [Required]
        public Guid StudentId { get; set; }

        /// <summary>
        /// Question Id
        /// </summary>
        [Required]
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Answer Id
        /// </summary>
        [Required]
        public Guid AnswerId { get; set; }

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
