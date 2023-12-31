﻿using API.Data.DTOs.Answer;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Question
{
    /// <summary>
    /// Question Edit Model
    /// </summary>
    public class QuestionEditModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Question String
        /// </summary>
        [Required]
        public string QuestionString { get; set; } = string.Empty;

        /// <summary>
        /// Course
        /// </summary>
        [Required]
        public Guid CourseId { get; set; }

        /// <summary>
        /// Answer
        /// </summary>
        public virtual IEnumerable<AnswerEditModel>? Answers { get; set; }

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
