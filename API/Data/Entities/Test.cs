namespace api.Data.Entities
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
        public int Duration { get; set; }
    }
}
