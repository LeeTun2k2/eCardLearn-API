﻿using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs.Answer
{
    /// <summary>
    /// Answer Add Model
    /// </summary>
    public class AnswerAddModel
    {
        /// <summary>
        /// Answer String
        /// </summary>
        [Required]
        public string AnswerString { get; set; } = string.Empty;

        /// <summary>
        /// Question
        /// </summary>
        [Required]
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Is true if the Answer is correct, else is false
        /// </summary>
        [Required]
        public bool IsCorrect { get; set; }

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
