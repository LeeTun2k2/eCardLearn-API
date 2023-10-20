using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Notification
{
    /// <summary>
    /// Notification Filter Model
    /// </summary>
    public class NotificationFilterModel
    {
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
