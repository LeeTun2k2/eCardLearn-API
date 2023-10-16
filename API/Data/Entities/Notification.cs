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
    }
}
