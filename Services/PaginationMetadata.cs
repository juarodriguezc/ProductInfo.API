namespace ProductsInfo.Services
{
    /// <summary>
    /// Class to Store the Pagination Metadata
    /// </summary>
    public class PaginationMetadata
    {
        /// <summary>
        /// Total Items in the result
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// Total Pages
        /// </summary>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// Size of the pages
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Current Page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="totalItemCount">Total Pages</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="currentPage">Current Page</param>
        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }
    }
}
