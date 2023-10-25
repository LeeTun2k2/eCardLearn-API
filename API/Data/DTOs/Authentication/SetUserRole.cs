namespace API.Data.DTOs.Authentication
{
    /// <summary>
    /// Set user role model
    /// </summary>
    public class SetUserRole
    {
        /// <summary>
        /// User's role is one of the followings: ["Student", "Teacher", "Administrator"] 
        /// </summary>
        public string UserRole { get; set; } = string.Empty;
    }
}
