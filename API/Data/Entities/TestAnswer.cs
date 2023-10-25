namespace API.Data.Entities
{
    /// <summary>
    /// Answer of test
    /// </summary>
    public class TestAnswer
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid TestAnswerId { get; set; }

        /// <summary>
        /// Test Id
        /// </summary>
        public Guid TestId { get; set; }

        /// <summary>
        /// Test
        /// </summary>
        public virtual Test? Test { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Student
        /// </summary>
        public virtual Student? Student { get; set; }

        /// <summary>
        /// Question Id
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Question
        /// </summary>
        public virtual Question? Question { get; set; }

        /// <summary>
        /// Answer Id
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Answer
        /// </summary>
        public virtual Answer? Answer { get; set; }

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
