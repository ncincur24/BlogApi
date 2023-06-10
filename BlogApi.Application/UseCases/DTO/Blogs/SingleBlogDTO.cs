using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApi.Application.UseCases.DTO.Comments;

namespace BlogApi.Application.UseCases.DTO.Blogs
{
    public class SingleBlogDTO : BlogDTO
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public IEnumerable<CommentDTO>? Comments { get; set; } = new List<CommentDTO>();
        public IEnumerable<LookUpDTO>? HashTags { get; set; } = new List<LookUpDTO>();
    }
}
