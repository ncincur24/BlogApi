using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO.Comments
{
    public class CreateCommentDTO
    {
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }
    }
}
