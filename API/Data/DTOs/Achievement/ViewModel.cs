namespace API.Data.DTOs.Achievement
{
    /// <summary>
    /// Achievement View Model
    /// </summary>
    public class AchievementViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid AchievementId { get; set; }

        /// <summary>
        /// Achievement Name
        /// </summary>
        public string AchievementName { get; set; } = string.Empty;

        /// <summary>
        /// Achievement Description
        /// </summary>
        public string AchievementDescription { get; set; } = string.Empty;

        /// <summary>
        /// Day Requirement
        /// </summary>
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
