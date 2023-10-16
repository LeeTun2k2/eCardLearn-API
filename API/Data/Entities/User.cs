using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    /// <summary>
    /// User
    /// </summary>
    public class User : IdentityUser<Guid>
    {
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
        /// Feedbacks
        /// </summary>
        public virtual IEnumerable<Feedback>? Feedbacks { get; set; }
    }
}
