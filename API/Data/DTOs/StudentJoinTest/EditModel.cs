﻿using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.StudentJoinTest
{
    /// <summary>
    /// StudentJoinTest Edit Model
    /// </summary>
    public class StudentJoinTestEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid StudentJoinTestId { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        [Required]
        public Guid StudentId { get; set; }

        /// <summary>
        /// TestId
        /// </summary>
        [Required]
        public Guid TestId { get; set; }

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
