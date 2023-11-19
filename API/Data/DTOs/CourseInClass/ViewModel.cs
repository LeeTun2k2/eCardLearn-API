using API.Data.DTOs.Class;
using API.Data.DTOs.Course;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.CourseInClass
{
    /// <summary>
    /// CourseInClass View Model
    /// </summary>
    public class CourseInClassViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid CourseInClassId { get; set; }

        /// <summary>
        /// Course Id
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public CourseViewModel? Course { get; set; }

        /// <summary>
        /// Class Id
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        public ClassViewModel? Class { get; set; }

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
