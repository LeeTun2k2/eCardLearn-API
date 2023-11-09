namespace API.Data.Entities
{
    /// <summary>
    /// Notification
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid NotificationId { get; set; }
        /// <summary>
        /// Notification Title
        /// </summary>
        public string NotificationTitle { get; set; } = string.Empty;

        /// <summary>
        /// Notification Content
        /// </summary>
        public string NotificationContent { get; set; } = string.Empty;

        /// <summary>
        /// Class Id
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public virtual Class? Class { get; set; }

        /// <summary>
        /// Teacher Id
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Teacher
        /// </summary>
        public virtual Teacher? Teacher { get; set; }

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
