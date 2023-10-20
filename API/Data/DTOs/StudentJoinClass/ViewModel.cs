namespace API.Data.DTOs.StudentJoinClass
{
    /// <summary>
    /// StudentJoinClass View Model
    /// </summary>
    public class StudentJoinClassViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid StudentJoinClassId { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// ClassId
        /// </summary>
        public Guid ClassId { get; set; }

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
