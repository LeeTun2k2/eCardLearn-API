namespace API.Data.Entities
{
    /// <summary>
    /// Student
    /// </summary>
    public class Student : User
    {
        /// <summary>
        /// Student Join Classes
        /// </summary>
        public virtual IEnumerable<StudentJoinClass>? StudentJoinClasses { get; set; }

        /// <summary>
        /// Student Join Tests
        /// </summary>
        public virtual IEnumerable<StudentJoinTest>? StudentJoinTests { get; set; }


        /// <summary>
        /// Student Join Tests
        /// </summary>
        public virtual IEnumerable<TestAnswer>? TestAnswers { get; set; }

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
