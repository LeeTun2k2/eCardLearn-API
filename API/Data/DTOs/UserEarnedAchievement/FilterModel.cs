using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.UserEarnedAchievement
{
    /// <summary>
    /// UserEarnedAchievement Filter Model
    /// </summary>
    public class UserEarnedAchievementFilterModel
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
