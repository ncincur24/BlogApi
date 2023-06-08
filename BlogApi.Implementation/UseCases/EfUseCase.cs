using BlogApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(BlogContext context)
        {
            Context = context;
        }
        public BlogContext Context { get; set; }
    }
}
