using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Entities
{
    public class Blog : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int ImageId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<HashTagBlog> HasTags { get; set; } = new List<HashTagBlog>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
