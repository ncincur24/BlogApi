using BlogApi.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.Commands.Blogs
{
    public interface IDeleteBlogCommand : ICommand<int>
    {
    }
}
