using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Question
{
    /// <summary>
    /// Question Filter Model
    /// </summary>
    public class QuestionFilterModel
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
