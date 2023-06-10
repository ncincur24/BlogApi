using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO.Searches
{
    public class BlogSearch : PageSearch
    {
        public IEnumerable<int>? Categories { get; set; } = new List<int>();
        public int? NumberOfComments { get; set; }
    }
}
