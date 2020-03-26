using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Pagination
{
    public class PagedCollection<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
