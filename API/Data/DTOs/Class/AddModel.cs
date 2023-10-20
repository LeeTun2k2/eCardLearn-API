using API.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Class
{
    /// <summary>
    /// Class Add Model
    /// </summary>
    public class ClassAddModel
    {
        /// <summary>
        /// Class Name
        /// </summary>
        [Required]
        public string ClassName { get; set; } = string.Empty;

        /// <summary>
        /// Class Description
        /// </summary>
        [Required]
        public string ClassDescription { get; set; } = string.Empty;

        /// <summary>
        /// Teacher
        /// </summary>
        [Required]
        public Guid TeacherId { get; set; }

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
