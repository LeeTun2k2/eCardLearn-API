using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Test
{
    /// <summary>
    /// Test Filter Model
    /// </summary>
    public class TestFilterModel
    {
        /// <summary>
        /// Test Name
        /// </summary>
        public string TestName { get; set; } = string.Empty;

        /// <summary>
        /// Test Description
        /// </summary>
        public string TestDescription { get; set; } = string.Empty;

        /// <summary>
        /// Test Date
        /// </summary>
        public DateTime TestDate { get; set; }

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
