﻿using API.Data.DTOs.Answer;

namespace API.Data.DTOs.Question
{
    /// <summary>
    /// Question View Model
    /// </summary>
    public class QuestionViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Question String
        /// </summary>
        public string QuestionString { get; set; } = string.Empty;

        /// <summary>
        /// Course
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Answer
        /// </summary>
        public virtual IEnumerable<AnswerViewModel>? Answers { get; set; }

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
