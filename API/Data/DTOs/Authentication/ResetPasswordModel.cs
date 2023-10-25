using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Authentication
{
    /// <summary>
    /// Password reset model
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Email must have format like "example@gmail.com"
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Password must contains at least ["0~9", "a~z", "A~Z", "-._@+"]
        /// </summary>
        [Required]
        [StringLength(32, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 8)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Confirm password must contains at least ["0~9", "a~z", "A~Z", "-._@+"]
        /// </summary>
        [Required]
        [StringLength(32, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 8)]
        public string ConfirmPassword { get; set; } = null!;

        /// <summary>
        /// Token
        /// </summary>
        [Required]
        public string Token { get; set; } = null!;
    }
}
