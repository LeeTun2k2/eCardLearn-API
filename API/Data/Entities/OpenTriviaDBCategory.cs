using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    /// <summary>
    /// Open Trivia DB Category
    /// </summary>
    public class OpenTriviaDBCategory
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string CategoryName { get; set;} = string.Empty;

        /// <summary>
        /// Open Trivia Id
        /// </summary>
        public int OpenTriviaId { get; set; }

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
