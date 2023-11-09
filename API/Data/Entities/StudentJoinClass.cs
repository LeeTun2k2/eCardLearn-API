namespace API.Data.Entities
{
    /// <summary>
    /// StudentJoinClass
    /// </summary>
    public class StudentJoinClass
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
        /// Student
        /// </summary>
        public virtual Student? Student { get; set; }

        /// <summary>
        /// ClassId
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public virtual Class? Class { get; set; }

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
