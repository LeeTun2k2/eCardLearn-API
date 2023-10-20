using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.UserEarnedAchievement
{
    /// <summary>
    /// UserEarnedAchievement Edit Model
    /// </summary>
    public class UserEarnedAchievementEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid UserEarnedAchievementId { get; set; }

        /// <summary>
        /// Id of User earned achievement
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Achievement
        /// </summary>
        [Required]
        public Guid AchievementId { get; set; }

        /// <summary>
        /// Date earned
        /// </summary>
        [Required]
        public DateTime DateEarned { get; set; }

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
