using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Notification
{
    /// <summary>
    /// Notification Edit Model
    /// </summary>
    public class NotificationEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid NotificationId { get; set; }

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
        /// Class Id
        /// </summary>
        [Required]
        public Guid ClassId { get; set; }

        /// <summary>
        /// Teacher Id
        /// </summary>
        [Required]
        public Guid TeacherId { get; set; }

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
