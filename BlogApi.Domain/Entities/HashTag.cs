using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Entities
{
    public class HashTag : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<HashTagBlog> Blogs { get; set; } = new List<HashTagBlog>();
    }
}
