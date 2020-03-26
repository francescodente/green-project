namespace GreenProject.Backend.Contracts.Filters
{
    public class PaginationFilter
    {
        public static int DEFAULT_PAGE_SIZE = 30;
        public static int DEFAULT_PAGE_NUMBER = 0;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            this.PageNumber = DEFAULT_PAGE_NUMBER;
            this.PageSize = DEFAULT_PAGE_SIZE;
        }

        public PaginationFilter NextPage()
        {
            return new PaginationFilter
            {
                PageSize = this.PageSize,
                PageNumber = this.PageNumber + 1
            };
        }

        public PaginationFilter PreviousPage()
        {
            return new PaginationFilter
            {
                PageSize = this.PageSize,
                PageNumber = this.PageNumber - 1
            };
        }
    }
}
