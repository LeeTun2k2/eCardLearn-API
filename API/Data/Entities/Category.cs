namespace api.Data.Entities
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Category Description
        /// </summary>
        public string CategoryDescription { get; set; } = string.Empty;
    }
}
