using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Test
{
    /// <summary>
    /// Test Filter Model
    /// </summary>
    public class TestFilterModel
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
