using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Entities
{
    public class HashTagBlog
    {
        public int BlogId { get; set; }
        public int HashTagId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual HashTag HashTag { get; set; }
    }
}
