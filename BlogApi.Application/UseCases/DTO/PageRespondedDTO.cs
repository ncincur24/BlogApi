using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO
{
    public class PageRespondedDTO<T> where T : class
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalItems / ItemsPerPage);

        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
