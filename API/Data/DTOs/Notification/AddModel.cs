using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Notification
{
    /// <summary>
    /// Notification Add Model
    /// </summary>
    public class NotificationAddModel
    {
        /// <summary>
        /// Notification Title
        /// </summary>
        [Required]
        public string NotificationTitle { get; set; } = string.Empty;

        /// <summary>
        /// Notification Content
        /// </summary>
        [Required]
        public string NotificationContent { get; set; } = string.Empty;

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
