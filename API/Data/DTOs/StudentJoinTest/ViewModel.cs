namespace API.Data.DTOs.StudentJoinTest
{
    /// <summary>
    /// StudentJoinTest View Model
    /// </summary>
    public class StudentJoinTestViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid StudentJoinTestId { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// TestId
        /// </summary>
        public Guid TestId { get; set; }

        /// <summary>
        /// Created User Id
        /// </summary>
        public Guid? CreatedUserId { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Updated User Id
        /// </summary>
        public Guid? UpdatedUserId { get; set; }

        /// <summary>
        /// Updated User Date
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
