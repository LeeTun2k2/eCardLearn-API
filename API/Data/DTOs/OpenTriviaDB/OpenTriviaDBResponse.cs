namespace API.Data.DTOs.OpenTriviaDB
{
    /// <summary>
    /// Open Trivia DB Response
    /// </summary>
    public class OpenTriviaDBResponse
    {
        /// <summary>
        /// Code 0: Success Returned results successfully.
        /// Code 1: No Results Could not return results.The API doesn't have enough questions for your query. (Ex. Asking for 50 Questions in a Category that only has 20.)
        /// Code 2: Invalid Parameter Contains an invalid parameter.Arguements passed in aren't valid. (Ex. Amount = Five)
        /// Code 3: Token Not Found Session Token does not exist.
        /// Code 4: Token Empty Session Token has returned all possible questions for the specified query.Resetting the Token is necessary.
        /// Code 5: Rate Limit Too many requests have occurred.Each IP can only access the API once every 5 seconds.
        /// </summary>
        public int Response_Code { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        public IList<OpenTriviaQuestion>? Results { get; set; }
    }

    /// <summary>
    /// Open Trivia question
    /// </summary>
    public class OpenTriviaQuestion
    {
        /// <summary>
        /// Type = multiple or True/False
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Easy, medium or hard
        /// </summary>
        public string Difficulty { get; set; } = string.Empty;

        /// <summary>
        /// Open Trivia Db Category
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Question
        /// </summary>
        public string Question { get; set; } = string.Empty;

        /// <summary>
        /// Correct Answer
        /// </summary>
        public string Correct_Answer { get; set; } = string.Empty;

        /// <summary>
        /// Incorrect Answers
        /// </summary>
        public IList<string>? Incorrect_Answers { get; set; }
    }
}
