namespace API.Data.DTOs.Authentication
{
    /// <summary>
    /// Login Model
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Email must have format like "example@gmail.com"
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password must contain at least ["0~9", "a~z", "A~Z", "-._@+"]
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Remember me login section
        /// </summary>
        public bool RememberMe { get; set; } = false;
    }
}
