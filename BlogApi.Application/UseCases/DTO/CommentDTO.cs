using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO
{
    public class CommentDTO : BaseDTO
    {
        public string CommentedBy { get; set; }
        public DateTime CommentedAt { get; set; }
        public string Comment { get; set; }
        public IEnumerable<CommentDTO>? Replies { get; set; } = new List<CommentDTO>();
    }
}
