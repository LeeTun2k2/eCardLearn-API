﻿namespace API.Data.Entities
{
    /// <summary>
    /// Achievement
    /// </summary>
    public class Achievement
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
        /// Date Earned
        /// </summary>
        public DateTime DateEarned { get; set; }

        /// <summary>
        /// Day Requirement
        /// </summary>
        public int DayRequirement { get; set; } = 0;

        /// <summary>
        /// Id of User earn achievement
        /// </summary>
        public Guid UserEarnId { get; set; }

        /// <summary>
        /// User earn achievement
        /// </summary>
        public virtual User? UserEarn { get; set; }

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
