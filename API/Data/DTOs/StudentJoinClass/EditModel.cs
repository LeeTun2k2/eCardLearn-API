using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.StudentJoinClass
{
    /// <summary>
    /// StudentJoinClass Edit Model
    /// </summary>
    public class StudentJoinClassEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid StudentJoinClassId { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        [Required]
        public Guid StudentId { get; set; }

        /// <summary>
        /// ClassId
        /// </summary>
        [Required]
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
