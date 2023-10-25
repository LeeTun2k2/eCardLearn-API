using API.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Authentication
{
    /// <summary>
    /// Register model
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// User name must be unique
        /// </summary>
        [Required]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Email must have format like "example@gmail.com"
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Password must contain at least ["0~9", "a~z", "A~Z", "-._@+"]
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [MinLength(UserPassword.Length.Min)]
        [MaxLength(UserPassword.Length.Max)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Phone must be unique
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Full name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Birth date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
