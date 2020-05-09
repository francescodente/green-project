using System;

namespace GreenProject.Backend.Contracts.Filters
{
    public class PaginationFilter
    {
        public const int MaxPageSize = 50;
        public const int DefaultPageSize = 30;
        public const int DefaultPageNumber = 0;

        private int pageSize;

        public int PageNumber { get; set; }

        public int PageSize
        {
            get => this.pageSize;
            set => this.pageSize = Math.Min(MaxPageSize, value);
        }

        public PaginationFilter()
        {
            this.PageNumber = DefaultPageNumber;
            this.PageSize = DefaultPageSize;
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
