using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.DTOs.Authentication
{
    /// <summary>
    /// User profile
    /// </summary>
    public class UserProfileModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Email must have format like "example@gmail.com"
        /// </summary>
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Phone number must have format like "0123 456 789"
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// Birth date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Is active
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Link to get avatar
        /// </summary>
        public string? AvatarUri { get; set; } = string.Empty;

        /// <summary>
        /// List role of user
        /// </summary>
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
