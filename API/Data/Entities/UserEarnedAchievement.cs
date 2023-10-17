namespace API.Data.Entities
{
    /// <summary>
    /// UserEarnedAchievement
    /// </summary>
    public class UserEarnedAchievement
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid UserEarnedAchievementId { get; set; }

        /// <summary>
        /// Id of User earned achievement
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// User earned achievement
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Achievement
        /// </summary>
        public Guid AchievementId { get; set; }

        /// <summary>
        /// Achievement 
        /// </summary>
        public virtual Achievement? Achievement { get; set; }

        /// <summary>
        /// Date earned
        /// </summary>
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
