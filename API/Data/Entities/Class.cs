namespace api.Data.Entities
{
    /// <summary>
    /// Class
    /// </summary>
    public class Class
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
    }
}
