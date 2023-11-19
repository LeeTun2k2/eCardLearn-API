namespace API.Data.Entities
{
    /// <summary>
    /// Test
    /// </summary>
    public class Test
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid TestId { get; set; }
        /// <summary>
        /// Test Name
        /// </summary>
        public string TestName { get; set; } = string.Empty;

        /// <summary>
        /// Test Description
        /// </summary>
        public string TestDescription { get; set; } = string.Empty;

        /// <summary>
        /// Test Start
        /// </summary>
        public DateTime TestStart { get; set; }

        /// <summary>
        /// Test End
        /// </summary>
        public DateTime TestEnd { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public int Duration { get; set; } = 0;

        /// <summary>
        /// Course id
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public Course? Course { get; set; }

        /// <summary>
        /// Student Join Tests
        /// </summary>
        public virtual IEnumerable<StudentJoinTest>? StudentJoinTests { get; set; }

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
