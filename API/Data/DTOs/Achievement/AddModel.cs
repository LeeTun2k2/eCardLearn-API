using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Achievement
{
    /// <summary>
    /// Achievement Add Model
    /// </summary>
    public class AchievementAddModel
    {
        /// <summary>
        /// Achievement Name
        /// </summary>
        [Required]
        public string AchievementName { get; set; } = string.Empty;

        /// <summary>
        /// Achievement Description
        /// </summary>
        [Required]
        public string AchievementDescription { get; set; } = string.Empty;

        /// <summary>
        /// Day Requirement
        /// </summary>
        [Required]
        public int DayRequirement { get; set; } = 0;

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
