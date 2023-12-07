using API.Data.DTOs.Answer;
using API.Data.DTOs.Question;

namespace API.Data.DTOs.TestResult
{
    /// <summary>
    /// TestResult 
    /// </summary>
    public class TestResult_Detail
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid DetailId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Question Id
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Question
        /// </summary>
        public QuestionViewModel? Question { get; set; }

        /// <summary>
        /// Answer Id
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Answer
        /// </summary>
        public AnswerViewModel? Answer { get; set; }

        /// <summary>
        /// Correct Answer Id
        /// </summary>
        public Guid CorrectAnswerId { get; set; }

        /// <summary>
        /// Correct Answer
        /// </summary>
        public AnswerViewModel? CorrectAnswer { get; set; }
    }
}
