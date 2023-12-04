using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.OpenTriviaDBCategory
{
    /// <summary>
    /// OpenTriviaDBCategory Filter Model
    /// </summary>
    public class OpenTriviaDBCategoryFilterModel
    {
        /// <summary>
        /// OpenTriviaDBCategory Name
        /// </summary>
        public string? CategoryName { get; set; } = string.Empty;

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
