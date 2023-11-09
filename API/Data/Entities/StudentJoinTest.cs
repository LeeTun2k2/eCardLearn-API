namespace API.Data.Entities
{
    /// <summary>
    /// StudentJoinTest
    /// </summary>
    public class StudentJoinTest
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
        /// Student
        /// </summary>
        public virtual Student? Student { get; set; }

        /// <summary>
        /// TestId
        /// </summary>
        public Guid TestId { get; set; }

        /// <summary>
        /// Test
        /// </summary>
        public virtual Test? Test { get; set; }

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
