using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO.Blogs
{
    public class BlogDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public IEnumerable<LookUpDTO> HashTags { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
