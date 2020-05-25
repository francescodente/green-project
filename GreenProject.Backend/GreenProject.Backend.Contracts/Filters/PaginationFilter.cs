using System;

namespace GreenProject.Backend.Contracts.Filters
{
    public class PaginationFilter
    {
        public const int MaxPageSize = 50;
        public const int DefaultPageSize = 30;
        public const int DefaultPageNumber = 0;

        private int _pageSize;

        public int PageNumber { get; set; }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = Math.Min(MaxPageSize, value);
        }

        public PaginationFilter()
        {
            PageNumber = DefaultPageNumber;
            PageSize = DefaultPageSize;
        }

        public PaginationFilter NextPage()
        {
            return new PaginationFilter
            {
                PageSize = PageSize,
                PageNumber = PageNumber + 1
            };
        }

        public PaginationFilter PreviousPage()
        {
            return new PaginationFilter
            {
                PageSize = PageSize,
                PageNumber = PageNumber - 1
            };
        }
    }
}
