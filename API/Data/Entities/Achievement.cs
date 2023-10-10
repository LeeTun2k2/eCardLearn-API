namespace api.Data.Entities
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
    }
}
