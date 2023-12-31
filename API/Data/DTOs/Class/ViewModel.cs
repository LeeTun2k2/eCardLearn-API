﻿using API.Data.DTOs.Course;

namespace API.Data.DTOs.Class
{
    /// <summary>
    /// Class View Model
    /// </summary>
    public class ClassViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Class Name
        /// </summary>
        public string ClassName { get; set; } = string.Empty;

        /// <summary>
        /// Class Description
        /// </summary>
        public string ClassDescription { get; set; } = string.Empty;

        /// <summary>
        /// Teacher
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Courses
        /// </summary>
        public IEnumerable<CourseViewModel>? Courses { get; set; }

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
