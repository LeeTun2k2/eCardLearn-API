﻿using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.CourseInClass
{
    /// <summary>
    /// CourseInClass Add Model
    /// </summary>
    public class CourseInClassAddModel
    {
        /// <summary>
        /// Course Id
        /// </summary>
        [Required]
        public Guid CourseId { get; set; }

        /// <summary>
        /// Class Id
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
