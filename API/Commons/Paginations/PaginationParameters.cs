namespace API.Commons.Paginations
{
    /// <summary>
    /// Pagination Parameters
    /// </summary>
    public class PaginationParameters
    {
        /// <summary>
        /// Page number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Dafault Constructor
        /// </summary>
        public PaginationParameters()
        {
            PageNumber = 0;
            PageSize = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PaginationParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
