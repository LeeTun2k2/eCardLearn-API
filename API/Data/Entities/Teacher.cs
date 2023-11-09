namespace API.Data.Entities
{
    /// <summary>
    /// Teacher
    /// </summary>
    public class Teacher : User
    {
        /// <summary>
        /// Courses
        /// </summary>
        public virtual IEnumerable<Course>? Courses { get; set; }

        /// <summary>
        /// Notifications
        /// </summary>
        public virtual IEnumerable<Notification>? Notifications { get; set; }
    }
}
