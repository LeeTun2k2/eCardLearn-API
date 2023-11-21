namespace API.Data.DTOs.UserLoginHistory
{
    /// <summary>
    /// UserLoginHistory View Model
    /// </summary>
    public class UserLoginHistoryViewModel
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
        /// Login date time
        /// </summary>
        public DateTime LoginDateTime { get; set; }

        /// <summary>
        /// Count maximum of login date
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
