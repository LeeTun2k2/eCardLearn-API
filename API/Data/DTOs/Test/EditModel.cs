using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Test
{
    /// <summary>
    /// Test Edit Model
    /// </summary>
    public class TestEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid TestId { get; set; }

        /// <summary>
        /// Test Name
        /// </summary>
        [Required]
        public string TestName { get; set; } = string.Empty;

        /// <summary>
        /// Test Description
        /// </summary>
        [Required]
        public string TestDescription { get; set; } = string.Empty;

        /// <summary>
        /// Test Start
        /// </summary>
        [Required]
        public DateTime TestStart { get; set; }

        /// <summary>
        /// Test End
        /// </summary>
        [Required]
        public DateTime TestEnd { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        [Required]
        public int Duration { get; set; } = 0;

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
