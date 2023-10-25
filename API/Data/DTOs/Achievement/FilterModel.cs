using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Achievement
{
    /// <summary>
    /// Achievement Filter Model
    /// </summary>
    public class AchievementFilterModel
    {
        /// <summary>
        /// Achievement Name
        /// </summary>
        public string AchievementName { get; set; } = string.Empty;

        /// <summary>
        /// Achievement Description
        /// </summary>
        public string AchievementDescription { get; set; } = string.Empty;

        /// <summary>
        /// Date Earned
        /// </summary>
        public DateTime DateEarned { get; set; }

        /// <summary>
        /// Day Requirement
        /// </summary>
        public int DayRequirement { get; set; } = 0;

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
