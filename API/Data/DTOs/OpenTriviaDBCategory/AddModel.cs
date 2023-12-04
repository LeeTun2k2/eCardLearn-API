using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.OpenTriviaDBCategory
{
    /// <summary>
    /// OpenTriviaDBCategory Add Model
    /// </summary>
    public class OpenTriviaDBCategoryAddModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Open Trivia Id
        /// </summary>
        [Required]
        public int OpenTriviaId { get; set; }

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
