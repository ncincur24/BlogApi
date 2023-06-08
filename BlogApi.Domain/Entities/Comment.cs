using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }

        public int UserId { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }

        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual Comment? ParentComment { get; set; }
        public virtual ICollection<Comment> ChildComment { get; set; } = new List<Comment>();

    }
}
