using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Answer
{
    /// <summary>
    /// Answer Filter Model
    /// </summary>
    public class AnswerFilterModel
    {
        /// <summary>
        /// Answer String
        /// </summary>
        public string AnswerString { get; set; } = string.Empty;

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
