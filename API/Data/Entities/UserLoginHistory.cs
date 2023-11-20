namespace API.Data.Entities
{
    /// <summary>
    /// UserLoginHistory
    /// </summary>
    public class UserLoginHistory
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid UserLoginHistoryId { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Login date time
        /// </summary>
        public DateTime LoginDateTime { get; set; }

        /// <summary>
        /// Count maximum of login date
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
