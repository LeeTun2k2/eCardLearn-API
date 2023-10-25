using API.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Authentication
{
    /// <summary>
    /// Change password model
    /// </summary>
    public class ChangePasswordModel
    {
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
        /// New password must contain at least ["0~9", "a~z", "A~Z", "-._@+"]
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [MinLength(UserPassword.Length.Min)]
        [MaxLength(UserPassword.Length.Max)]
        public string NewPassword { get; set; } = null!;

        /// <summary>
        /// Confirm new password must contain at least ["0~9", "a~z", "A~Z", "-._@+"]
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [MinLength(UserPassword.Length.Min)]
        [MaxLength(UserPassword.Length.Max)]
        public string ComfirmationNewPassword { get; set; } = null!;
    }
}
