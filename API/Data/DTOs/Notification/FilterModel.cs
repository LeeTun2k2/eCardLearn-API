using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Notification
{
    /// <summary>
    /// Notification Filter Model
    /// </summary>
    public class NotificationFilterModel
    {
        /// <summary>
        /// Notification Title
        /// </summary>
        public string NotificationTitle { get; set; } = string.Empty;

        /// <summary>
        /// Notification Content
        /// </summary>
        public string NotificationContent { get; set; } = string.Empty;

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
